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
        public IActionResult Index()
        {
            var joblist = jobRepository.GetAll();
            return View(joblist);
        }


        [HttpGet]
        public ActionResult Insert()

        {
            
            return View();

        }
        [HttpPost]
        public ActionResult Insert(FormCollectionModelBinder form, JobEntity objpost)

        {
            try
            {
                jobRepository.Insert(objpost);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }         

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

            catch (Exception ex)

            {

                throw ex;


            }


        }

        [HttpGet]
        public ActionResult Delete(Guid id)

        {
            try
            {
                var job = jobRepository.GetById(id);
                return View(job);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            

        }

        [HttpPost]
        public ActionResult DeleteJob(Guid id)

        {
            try
            {

                jobRepository.Delete(id);
                var joblist = jobRepository.GetAll();
                return View("Index", joblist);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


    }
}
