using EmailServiceProject.Controllers;
using EmailServiceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using Microsoft.Extensions.Configuration;
using EmailServiceProject.ConfigSettingsCode;

namespace EmailServiceProject.Controllers
{

    [Route("api/[controller]")] //controller is sentemail
    [ApiController]
    public class MailsController : Controller
    {
        private readonly AppDbContext _context;

        public MailsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet] //get method to get the list of sent mails.
        public async Task<IActionResult> GetEmail()
        {
            return Ok(await _context.Mails.ToListAsync());
        }

        [HttpGet] //get method to get the list of mails by Id.
        [Route("{id}")]
        public async Task<IActionResult> GetMailById(int id)
        {
            var email = await _context.Mails.FindAsync(id);

            if (email == null) //if user with id was not found in the database
            {
                return NotFound();
            }
            return Ok(email);

        }


        [HttpPost] //post method to create a mail
        public async Task<IActionResult> CreateEmail(Mail email)
        {
            //The e-mail address to which the e-mail will be sent must be registered in the e-mail list.
            var existingEmail = await _context.Users.FirstOrDefaultAsync(e => e.emailAdress == email.toEmail);
            if (existingEmail == null) //If the e-mail address to which the e-mail will be sent
                                       //is not previously defined in the database
            {
                return BadRequest();
            }
            else
            {
                emailAdressConfig to_Adress = new emailAdressConfig();
                if (to_Adress.IsValidEmail(email.toEmail))
                {
                    await _context.Mails.AddAsync(email);
                    //The changes made are saved to the database asynchronously.
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetEmail", new { id = email.Id }, email);
                }
                
                return BadRequest(); //The e-mail is sent only to the user whose e-mail address is xxxx@ssttek.com
            }
        }


        [HttpDelete("{id}")] //delete method to delete a mail by id
        public async Task<IActionResult> DeleteEmail(int id)
        {
            var email = await _context.Mails.FindAsync(id);
            if (email == null)
            {
                return NotFound(); 
            }

            _context.Mails.Remove(email);
            await _context.SaveChangesAsync();
   
            return Ok("E-mail from " + email.fromEmail + " " +"to " + email.toEmail
                + ": " + email.Message +" is deleted ");
        }


    }
}

