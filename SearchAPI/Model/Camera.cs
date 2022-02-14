using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAPI.Model;

public class Camera
{
    private CultureInfo cultureInfo = new CultureInfo("en-US");

    public int Id { get; }
    public string Name { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    public Camera(string data)
    {
        string[] dataSplit = data.Split(';');
        string name = dataSplit[0];
        string nameId = name.Split(' ').First();
        Id = int.Parse(nameId.Split('-')[2]);
        Name = dataSplit[0];
        Latitude = double.Parse(dataSplit[1], cultureInfo);
        Longitude = double.Parse(dataSplit[2], cultureInfo);
    }

    public override string ToString()
    {
        return $"{Id} | {Name} | {Latitude.ToString("G", cultureInfo)} | {Longitude.ToString("G", cultureInfo)}";
    }
}
