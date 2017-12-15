using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Domain;
using ToDoList.Infrastructure;
using ToDoList.Models.ToDoList;

namespace ToDoList.Pages.ToDoList
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddModel(ApplicationDbContext dbContext, 
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [BindProperty]
        public ActivityModel Activity { get; set; }
        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var activity = _mapper.Map<Activity>(Activity);

            await _dbContext.Activities.AddAsync(activity);
            await _dbContext.SaveChangesAsync();

            Message = $"Activity {Activity.Name} added.";

            return RedirectToPage("Index");
        }
    }
}