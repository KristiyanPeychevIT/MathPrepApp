namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models;
    using MathPreparationApp.Services.Data.Interfaces;
    using ViewModels.Subject;
    using static Common.GeneralApplicationConstants;

    [Authorize]
    public class SubjectController : Controller
    {
        private readonly ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add(SubjectFormModel model)
        {
            bool isIdTaken =
                await this.subjectService.SubjectExistsByIdAsync(model.Id);
            if (isIdTaken)
            {
                ModelState.AddModelError(nameof(model.Id), "Subject with this Id already exists!");
            }

            bool isNameTaken =
                await this.subjectService.SubjectExistsByNameAsync(model.Name);
            if (isNameTaken)
            {
                ModelState.AddModelError(nameof(model.Id), "Subject with this Name already exists!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.subjectService.AddAsync(model);
            }
            catch (Exception)
            {
                throw new Exception("Unexpected error occured while adding a subject!");
            }

            return this.RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id)
        {
            Subject subject = await this.subjectService.GetSubjectByIdAsync(id);

            if (subject == null)
            {
                return BadRequest();
            }

            SubjectFormModel model = new SubjectFormModel()
            {
                Name = subject.Name
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id, SubjectFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await subjectService.EditAsync(id, model);
            }
            catch (Exception)
            {
                throw new Exception("Unexpected error occured while editing a subject!");
            }

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await this.subjectService.GetSubjectByIdAsync(id);

            if (subject == null)
            {
                return BadRequest();
            }

            SubjectViewModel model = new SubjectViewModel()
            {
                Id = subject.Id,
                Name = subject.Name,
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Delete(SubjectViewModel model)
        {
            try
            {
                await subjectService.DeleteAsync(model);
            }
            catch (Exception)
            {
                throw new Exception("Unexpected error occured while deleting a subject!");
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}
