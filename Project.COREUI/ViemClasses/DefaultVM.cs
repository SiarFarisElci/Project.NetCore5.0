using Project.ENTITIES.Entities;
using System.Collections.Generic;

namespace Project.COREUI.ViemClasses
{
	public class DefaultVM
	{
		public Adress  Adress { get; set; }
		public Service Service { get; set; }
		public About About { get; set; }
		public Team	 Team { get; set; }
		public New	 New { get; set; }
		public Image Image { get; set; }
		public Contact Contact	 { get; set; }
		public List<Contact> Contacts	 { get; set; }
		public List<Image> Images { get; set; }
		public List<New>	 News { get; set; }
		public List<Team>	 Teams { get; set; }
		public List<Adress>  Adresses { get; set; }
		public List<About>   Abouts { get; set; }
		public List<Service>    Services { get; set; }
	}
}
