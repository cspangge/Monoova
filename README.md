# Monoova
Monoova ASP.NET Framework

Sample

private readonly Tools _tools;
        
public HomeController()
{
    var monoovaHelper = new MonoovaHelper();
    _tools = new Tools(monoovaHelper);
}

public async Task<ViewResult> Index()
{
    await _tools.Ping();
    await _tools.ValidateAbn("15167507039");
    await _tools.ValidateBsb("062-624");
    return View();
}
