using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Infrastructure;
using ToDoList.Models.ToDoList;

namespace ToDoList.Pages.ToDoList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public IndexModel(ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IList<ActivityModel> Activities { get; set; }
        [TempData]
        public string Message { get; set; }
        public bool HasMessage => !string.IsNullOrWhiteSpace(Message);

        public void OnGet()
        {
            Activities = _mapper.Map<IList<ActivityModel>>(_dbContext.Activities);
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var contact = await _dbContext.Activities.FindAsync(id);

            if (contact != null)
            {
                _dbContext.Activities.Remove(contact);
                await _dbContext.SaveChangesAsync();

                Message = "Activity removed succesfully.";
            }

            return RedirectToPage();
        }
    }
}