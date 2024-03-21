using MathPreparationApp.Data.Models;

namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;
    using ViewModels.Subject;
    using MathPreparationApp.Services.Data;
    using MathPreparationApp.Web.Infrastructure.Extensions;

    [Authorize]
    public class SubjectController : Controller
    {
        private readonly ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return this.View();
        }

        [HttpPost]
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

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
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
        public async Task<IActionResult> Edit(int id, SubjectFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await subjectService.EditAsync(id, model);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
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
        public async Task<IActionResult> Delete(SubjectViewModel model)
        {
            await subjectService.DeleteAsync(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
