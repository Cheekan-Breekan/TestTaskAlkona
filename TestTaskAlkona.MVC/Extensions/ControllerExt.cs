using Microsoft.AspNetCore.Mvc;

namespace TestTaskAlkona.MVC.Extensions;

public class ControllerExt
{
    public static string NameOf<T>() where T : Controller
    {
        return typeof(T).Name.Replace("Controller", string.Empty);
    }
}
