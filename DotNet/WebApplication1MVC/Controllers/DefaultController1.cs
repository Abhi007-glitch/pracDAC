using Microsoft.AspNetCore.Mvc;

namespace WebApplication1MVC.Controllers
{

    // for each controller we need to have a seprated folder by the name of Controller inside the views directory 
    public class DefaultController1 : Controller
    {
        //*************** These actions can any implementation (derived class of ActionResult)
        // Derived Class of ActionResult - ViewResult (have derived class of view), statusCode ( have Derived classes of NotFound)
        // int? id -> ? used for a reason ( to have null value inseted of default value of 0 [we don't pass any value ]) 
        public IActionResult Index(int? id)  // value binding based on name (passed form the controller)  (so need to have same name)
         // receving parameter  if no id value passed then it takes a default value (0)  
        {
            // return View("Index1") -- specifying  a partucluar view to be return (not a prefered way)
          
            if (id==null)
            {
                return NotFound();
            }
            else
            {
                return View(id);
            }
           

            //return NotFound();
        }
    }
}
