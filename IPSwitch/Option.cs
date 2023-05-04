namespace IPSwitch
{
    public class Option
    {
        private string type;
        private string name;
        private string value_;

        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public string Value { get => value_; set => value_ = value; }
    }
}
