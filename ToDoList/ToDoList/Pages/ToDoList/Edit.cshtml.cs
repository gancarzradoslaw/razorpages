using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;
using ToDoList.Infrastructure;
using ToDoList.Models.ToDoList;

namespace ToDoList.Pages.ToDoList
{
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EditModel(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public ActivityModel Activity { get; set; }

        public async Task<IActionResult> OnGet(Guid id)
        {
            var activity = await _dbContext.Activities.FindAsync(id);
            if (activity == null)
            {
                return RedirectToPage("Index");
            }

            Activity = _mapper.Map<ActivityModel>(activity);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var activity = _mapper.Map<Activity>(Activity);

            _dbContext.Attach(activity).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Activity {Activity.Id} not found!");
            }


            Message = $"Activity {Activity.Name} added.";

            return RedirectToPage("Index");
        }
    }
}