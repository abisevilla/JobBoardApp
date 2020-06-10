using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardApp.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {



                context.Jobs.AddRange(
                     new JobEntity
                     {
                         JobTitle = "Frontend Developer",
                         CreatedAt = DateTime.Now,
                         Job = "Part-time",
                         Description = "Design a framework for creating user apps that grows with the needs of the company Monitor website performance,  watch for traffic drops related to site usability problems and rectify the issues Review app and feature coding and plan future website upgrades with the development team" 
                     }, 
                       new JobEntity
                       {
                           JobTitle = "Full Stack Developer",
                           CreatedAt = DateTime.Now,
                           Job = "Full-time",
                           Description = "Code in Node, Express, and React while choosing modern libraries to develop in Collaborate with your friendly,  enthusiastic,  and senior teammates Create clean, modern, testable, well - documented code each sprint Use GitHub, ZenHub and burndown charts to manage the development Confidently communicate daily with clients to understand and deliver technical requirements"
                       },


                    new JobEntity
                    {
                        JobTitle = "Electrical Engineer",
                        CreatedAt = DateTime.Now,
                        Job = "Generate FPGA level derived requirements from module level flow down.",
                        Description = "Responsible for architecting, designing, developing, modifying, evaluating and integrating FPGA blocks for complex, high performance hardware systems.Determines design approaches and parameters.Analyzes FPGA requirements to determine feasibility of design within time and cost constraints.Able to identify FPGA operational characteristics that may impact system performance and or sustainability.May also review vendor capability to support development."
                    },
                      new JobEntity
                      {
                          JobTitle = "Administrative Assistant / Receptionist",
                          CreatedAt = DateTime.Now,
                          Job = "Full Time",
                          Description = "hared support of front desk and Bothell Office operations Bothell office event coordination including monthly gatherings and recurring employee recognition Greet and announce lobby guests and scheduled appointments Answer and route incoming main line calls Organize and distribute incoming mail, faxes, parcels and signature deliveries Stock and maintain office supply inventory and work room area Providing content management for video monitors and intranet employee communication"
                      }
            );

                context.SaveChanges();
            }
        }
    }
}
