using Service;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace webApp_test.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userService.Get(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(Model.User model)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(model);
                ViewBag.Message = "The user has been updated.";
            }

            return View(model);
        }
        
        public JsonResult EditUser(Model.User model)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(model);
                var message = "The user has been updated.";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                                .Select(x => x.Value.Errors.First().ErrorMessage).ToList();
                return Json(errors, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Model.User());
        }

        [HttpPost]
        public ActionResult Add(Model.User model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "The user has been created.";
                _userService.Add(model);
            }

            return View(model);
        }

        public JsonResult AddUser(Model.User model)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(model);
                return Json("The user has been created.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                                .Select(x => x.Value.Errors.First().ErrorMessage).ToList();
                return Json(errors, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetUsers()
        {
            var users = _userService.GetAll();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}