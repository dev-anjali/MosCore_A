using Microsoft.AspNetCore.Mvc;

namespace MosCore.Web.Views.Shared.Components.FormModal
{
    public class FormModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}