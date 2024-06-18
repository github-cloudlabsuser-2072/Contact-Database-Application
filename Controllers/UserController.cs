using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // This method is responsible for displaying the list of users.
            // It retrieves the list of users from the userlist and passes it to the Index view.
            
            return View("Index", userlist);
        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // This method is responsible for displaying the details of a specific user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Details view.
            return View("Details", userlist.FirstOrDefault(x => x.Id == id));
        }
 
        // GET: User/Create
        public ActionResult Create()
        {
            // This method is responsible for displaying the view to create a new user.
            return View();
        }
 
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
            // This method is responsible for handling the HTTP POST request to create a new user.
            // It receives user input from the form submission and adds the new user to the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If an error occurs during the process, it returns the Create view to display any validation errors.
            try
            {
                if (ModelState.IsValid)
                {
                    userlist.Add(user);
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            return View(userlist.FirstOrDefault(x => x.Id == id));
        }
 
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            try
            {
                if (ModelState.IsValid)
                {
                    var userToUpdate = userlist.FirstOrDefault(x => x.Id == id);
                    if (userToUpdate != null)
                    {
                        userToUpdate.Name = user.Name;
                        userToUpdate.Email = user.Email;
                        return RedirectToAction("Index");
                    }
                    return HttpNotFound();
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            // This method is responsible for displaying the view to delete an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Delete view.
            return View(userlist.FirstOrDefault(x => x.Id == id));
        }
 
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // This method is responsible for handling the HTTP POST request to delete an existing user with the specified ID.
            // It removes the corresponding user from the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            try
            {
                var userToDelete = userlist.FirstOrDefault(x => x.Id == id);
                if (userToDelete != null)
                {
                    userlist.Remove(userToDelete);
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }
            catch
            {
                return View();
            }
        }
    }
}
