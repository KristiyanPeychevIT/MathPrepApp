namespace MathPreparationApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MathPreparationApp.Services.Data.Interfaces;
    using ViewModels.Subject;
    using MathPreparationApp.Services.Data;

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
                await this.subjectService.AddSubject(model);
            }
            catch (Exception)
            {
                throw new Exception("Unexpected error occured while adding a subject!");
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
