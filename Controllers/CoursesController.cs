using BigSchool.Models;
using BigSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        public readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        [HttpPost]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        public ActionResult Create(CoursesViewModel viewModel)
        {
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DataTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
        }
    }
}