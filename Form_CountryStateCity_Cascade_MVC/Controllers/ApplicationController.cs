using Form_CountryStateCity_Cascade_MVC.Models;
using Form_CountryStateCity_Cascade_MVC.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Form_CountryStateCity_Cascade_MVC.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IApplicationFormRepository _appRepo;
        private readonly ICountryRepository _countryRepo;
        private readonly IStateRepository _stateRepo;

        public ApplicationController(
            IApplicationFormRepository appRepo,
            ICountryRepository countryRepo,
            IStateRepository stateRepo)
        {
            _appRepo = appRepo;
            _countryRepo = countryRepo;
            _stateRepo = stateRepo;
        }

        // ✅ Show List Page
        public IActionResult Index()
        {
            var data = _appRepo.GetAll()?.ToList() ?? new List<ApplicationForm>(); // null safe
            return View(data);
        }

        // ✅ Show Create Form Page
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Countries = new SelectList(_countryRepo.GetAll(), "Id", "Name");
            return View();
        }

        // ✅ Handle Create Post Request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationForm form)
        {
            ModelState.Remove("Country");
            ModelState.Remove("State");

            if (ModelState.IsValid)
            {
                _appRepo.Insert(form);
                _appRepo.Save();
                TempData["Success"] = "Application created successfully!";
                return RedirectToAction("Index");
            }

            // Reload dropdowns if model state invalid
            ViewBag.Countries = new SelectList(_countryRepo.GetAll(), "Id", "Name", form.CountryId);
            return View(form);
        }
        // GET: Edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var application = _appRepo.GetById(id);
            if (application == null)
                return NotFound();

            ViewBag.Countries = new SelectList(_countryRepo.GetAll(), "Id", "Name", application.CountryId);
            ViewBag.States = new SelectList(_stateRepo.GetStatesByCountryId(application.CountryId), "Id", "Name", application.StateId);

            return View(application);
        }

        // POST: Update data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationForm form)
        {
            ModelState.Remove("Country");
            ModelState.Remove("State");

            if (ModelState.IsValid)
            {
                _appRepo.Update(form);
                _appRepo.Save();
                TempData["Success"] = "Application updated successfully!";
                return RedirectToAction("Index");
            }

            ViewBag.Countries = new SelectList(_countryRepo.GetAll(), "Id", "Name", form.CountryId);
            ViewBag.States = new SelectList(_stateRepo.GetStatesByCountryId(form.CountryId), "Id", "Name", form.StateId);

            return View(form);
        }

        // ✅ Ajax Call to Load States by Country
        public JsonResult GetStates(int countryId)
        {
            var states = _stateRepo.GetStatesByCountryId(countryId);
            return Json(states);
        }

        // GET: Confirm Delete Page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var application = _appRepo.GetAll().FirstOrDefault(x => x.Id == id);
            if (application == null)
                return NotFound();

            return View(application);
        }

        // POST: Perform Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _appRepo.Delete(id);
            _appRepo.Save();
            TempData["Success"] = "Application deleted successfully!";
            return RedirectToAction("Index");
        }

    }
}
