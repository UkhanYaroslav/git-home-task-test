﻿using System;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Models;

namespace ADO.NET
{
    class Program
    {
        // Student TASK
        // Update the connection string located in appSettings.json file
        // Make the program to execute without exceptions.
        // Check that the results are correct in DB.

        private static string _connectionString;
        static void Main(string[] args)
        {
            SetConnectionString();

            IRepository<Course> courseRepository = GetCourseRepository();
            Course newCourse = new Course() { StartDate = DateTime.Now, EndDate = DateTime.Now, PassCredits = 2, Name="My_course"};

            var course = courseRepository.Create(newCourse);
            course.PassCredits = 3;

            courseRepository.Update(course);

            IRepository<Student> studentRepository = GetStudentRepository();
            Student newStudent = new Student()
            {
                BirthDate = DateTime.Now,
                Email = "Yaroslav@mail.ua",
                GitHubLink = "http_link",
                Name = "Yarek",
                PhoneNumber = "+380"
            };
            var insertedStudent = studentRepository.Create(newStudent);

            //Update

            insertedStudent.Notes += "; Programmer"; 
            insertedStudent.Courses.Add(course);

            studentRepository.Update(insertedStudent);
            studentRepository.Remove(insertedStudent.Id);
            courseRepository.Remove(course.Id);
        }

        private static IRepository<Course> GetCourseRepository()
        {
            return new CourseRepository(_connectionString);
        }

        private static IRepository<Student> GetStudentRepository()
        {
            return new StudentRepository(_connectionString);
        }

        private static void SetConnectionString()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile($"appsettings.json", true, true);
            var configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}