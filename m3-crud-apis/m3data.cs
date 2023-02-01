namespace m3_crud_apis
{
    public class Data
    {
        public string resultType { get; set; }
        public List<Result> result { get; set; }
    }

    public class Metric
    {
        public string __name__ { get; set; }
        public string checkout { get; set; }
        public string city { get; set; }
    }

    public class Result
    {
        public Metric metric { get; set; }
        public List<List<object>> values { get; set; }
    }

    public class Root
    {
        public string status { get; set; }
        public Data data { get; set; }
    }

}
