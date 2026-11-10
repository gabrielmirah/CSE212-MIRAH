public class FeatureCollection
{
    public List<Feature> Features { get; set; } = new List<Feature>();
}

public class Feature
{
    public EarthquakeProperties Properties { get; set; } = new EarthquakeProperties();
}

public class EarthquakeProperties
{
    public string Place { get; set; } = string.Empty;

    public double? Mag { get; set; }
}