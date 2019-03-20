using Entities.Responses;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Api.Models.Book
{
    public class BookEditViewModel
    {
        public BookResponse Book { get; set; }
        public SelectListItem[] AllLanguages { get; set; }
        public SelectListItem[] AllCategories { get; set; }
        public SelectListItem[] AllAuthors { get; set; }
        public SelectListItem[] AllPublishers { get; set; }
    }
}