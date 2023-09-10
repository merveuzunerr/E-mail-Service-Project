using EmailServiceProject.Controllers;
using EmailServiceProject.Models;
using EmailServiceProject.ConfigSettingsCode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace EmailServiceProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet] //get method to get the list of Users.
        public async Task<IActionResult> GetUser() {

            return Ok(await _context.Users.OrderBy(x => x.Id).ToListAsync());
            ; }

        [HttpGet] //get method to get the list of Users by Id.
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var email = await _context.Users.FindAsync(id);

            if (email == null) //if user with id was not found in the database
            {
                return NotFound();
            }
            return Ok(email);

        }

        [HttpPost] //post method to create a user to send a mail
        public async Task<IActionResult> CreateUser(User email)
        {
            emailAdressConfig email_Adress = new emailAdressConfig();
            if (email_Adress.IsValidEmail(email.emailAdress))
            {
                await _context.Users.AddAsync(email);
                //The changes made are saved to the database asynchronously.
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEmail", new { id = email.Id }, email);

            }
            return BadRequest();
        }

        [HttpPut("{id}")] //update method to update a user informations
        public async Task<IActionResult> UpdateUser(int id, User updatedEmail)
        {
            var email = await _context.Users.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }
            email.emailAdress = updatedEmail.emailAdress;
            email.firstName = updatedEmail.firstName;
            email.lastName = updatedEmail.lastName;


            _context.Users.Update(email); //database updated
            await _context.SaveChangesAsync();
            return Ok("The user information has been updated successfully!");
        }

        [HttpDelete("{id}")] //delete method to delete a user by id
        public async Task<IActionResult> DeleteUser(int id)
        {
            var email = await _context.Users.FindAsync(id);
            
            if (email == null) //if user with id was not found in the database
            {
                return NotFound();
            }

            _context.Users.Remove(email);//delete user information
            await _context.SaveChangesAsync();

            return Ok("Email adress:" + email.emailAdress+" is deleted ");
        }
    }
}










