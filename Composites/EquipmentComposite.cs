namespace Pps.Avpratica.Composites
{
    public class EquipmentComposite : Equipment
    {
        protected static EquipmentComposite? _instance;
        public EquipmentComposite()
        {}

        public static EquipmentComposite GetInstance()
        {
            if (_instance == null)
                _instance = new EquipmentComposite();

            return _instance;
        }

        protected List<Equipment> Equipments = new List<Equipment>();
        public void Add(Equipment e)
        {
            this.Equipments.Add(e);
            Console.WriteLine("Quantidade: " + this.Equipments.Count);
        }
        public void Remove(Equipment e)
        {
            this.Equipments.Remove(e);
            Console.WriteLine("Quantidade: " + this.Equipments.Count);
        }

        public override void SetRegistry(Registry registry)
        {
            this.Registry = registry;
        }

        public int GetEquipmentAmount(Registry registry)
        {
            var count = 0;

            foreach (var equipment in this.Equipments)
            {
                if (registry == equipment.Registry)
                {
                    count++;
                }
            }

            return count;
        }
    }
}