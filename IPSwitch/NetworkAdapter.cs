namespace IPSwitch
{
    public class NetworkAdapter : Network
    {
        string nicId; //网卡ID

        public string NicId
        {
            get
            {
                return nicId;
            }
            set
            {
                nicId = value;
            }
        }
    }
}
