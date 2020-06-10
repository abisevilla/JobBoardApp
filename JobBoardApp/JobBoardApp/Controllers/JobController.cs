using JobBoardApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardApp.Models
{
    public class JobController : Controller
    {
        private IRepository<JobEntity> jobRepository;
        public JobController(IRepository<JobEntity> jobRepository)
        { this.jobRepository = jobRepository; }

        [HttpGet]
        [Route("GetAllJobs")]
        public IEnumerable<JobEntity> GetAllJobs() => jobRepository.GetAll();

        [HttpGet]
        [Route("{JobId}")]
        public JobEntity GetJobById(Guid bookId) => jobRepository.GetById(bookId);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddJob([FromBody] JobEntity job) => jobRepository.Insert(job);

        [HttpDelete]
        [Route("{JobId}")]
        [AllowAnonymous]
        public void DeleteJob(Guid jobId) => jobRepository.Delete(jobId);

        public IActionResult Index()
        {
            var joblist = jobRepository.GetAll();
            return View(joblist);
        }

      



        [HttpGet]
        public ActionResult Edit(Guid id)

        {
            var job = jobRepository.GetById(id);
            return View(job);

        }

        [HttpPost]
        public ActionResult Edit( FormCollectionModelBinder form, JobEntity objpost)

        {
            try

            {
                jobRepository.Update(objpost);



                return RedirectToAction("Index");

            }

            catch (Exception e)

            {

                return View();


            }


        }
    }
}
