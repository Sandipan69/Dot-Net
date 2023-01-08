﻿using ClassroomManagement.web.DTOs.Student;
using ClassroomManagement.web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomManagement.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _iStudentService;

        public StudentController(IStudentService studentService)
        {
            _iStudentService = studentService;
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost("AddStudent")]
        public async Task<string> PostStudent(CreateStudentDTO _newStudnet)
        {
            return await _iStudentService.AddStudent(_newStudnet);
        }
        [Authorize(Roles = "Student,Teacher")]
        [HttpGet("GetAllStudent")]
        public ActionResult<List<GetStudentDTO>> GetAllStudents()
        {
            return Ok(_iStudentService.FetchStudentsList());
        }
        [Authorize(Roles = "Student,Teacher")]
        [HttpGet("GetSingleStudent")]
        public ActionResult<GetStudentDTO> GetSingleStudent(int id)
        {
            return Ok(_iStudentService.FetchSingleStudent(id));
        }
        [Authorize(Roles = "Teacher")]
        [HttpPut("EditStudent")]
        public async Task<string> PutStudent(UpdateStudentDTO _student)
        {
            return await _iStudentService.UpdateStudent(_student);
        }
        [Authorize(Roles = "Teacher")]
        [HttpPut("EditScore")]
        public async Task<string> PutStudnetScore(int Id, int Score)
        {
            return await _iStudentService.UpdateScore(Id, Score);
        }
        [Authorize(Roles = "Teacher")]
        [HttpDelete("DeleteStudent")]
        public async Task<string> DeleteStudent(int Id)
        {
            return await _iStudentService.DeleteStudent(Id);
        }
    }
}