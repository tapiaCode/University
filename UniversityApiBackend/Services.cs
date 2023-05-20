using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend
{
    public class Services
    {
        private readonly UniversityDBContext _context;
        public Services(UniversityDBContext context)
        {
            _context = context;
        }


        public void searchByEmail()
        {
            var usersByEmail = from a in _context.Users select a.Email;

            foreach (var user in usersByEmail)
            {
                Console.WriteLine(user);
            }
        }

        public void searchAdult()
        {
            DateTime today = DateTime.Now;
            DateTime eighteenYearsAgo = today.AddDays(-18);

            var adultUsers = _context.Students.Where(a => a.Dob <= eighteenYearsAgo).ToList();

            foreach (var user in adultUsers)
            {
                Console.WriteLine(user);
            }
        }

        public void searchStudentsAtLeastOneCourse()
        {
            var studentLeastCourse = _context.Students.Any(a => a.Courses.Any());
        }

        public void levelCourses()
        {
            var coursesByLevel = _context.Courses.Where(a => a.Level == Level.Basic && a.Students.Any()).ToList();

            foreach(var course in coursesByLevel)
            {
                Console.WriteLine(course);
            }
        }

        public void searchCoursesWithCategory()
        {
            var coursesCategories = _context.Courses.Where(a => a.Level == Level.Medium && a.Categories == _context.Categories.Where(b => b.Name.Equals("Expert"))).ToList();
        }

        public void coursesWithoutStudent()
        {
            var coursesWithout = _context.Courses.Where(a => !a.Students.Any()).ToList();
        }
    }
}
