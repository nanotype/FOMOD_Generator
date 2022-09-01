using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test_databind.Modules.RoomCarto
{
	/// <summary>
	/// Logique d'interaction pour RoomCarto.xaml
	/// </summary>
	public partial class RoomCarto : UserControl
	{
		private Donjon Donjon { get; set; } = new Donjon();
		public RoomCarto()
		{
			InitializeComponent();
		}

		private void DrawMap()
		{
			int size = 25;
			int space = 5;
			foreach (List<Room> roomList in Donjon.Rooms)
			{
				foreach (Room room in roomList)
				{
					Rectangle rectangle = new Rectangle
					{
						Width = size,
						Height = size
					};

					switch (room.RoomType)
					{
						case RoomType.Start:
							rectangle.Fill = Brushes.LightGreen;
							break;
						case RoomType.Item:
							break;
						case RoomType.Marchant:
							break;
						case RoomType.Boss:
							break;
						case RoomType.Secret:
							break;
						case RoomType.Nothing:
							rectangle.Fill = Brushes.White;
							break;
						case RoomType.plus:
							rectangle.Fill = Brushes.Silver;
							break;
						case RoomType.NotExist:
							break;
						default:
							rectangle.Fill = Brushes.Black;
							break;
					}

					dessin.Children.Add(rectangle);

					//Canvas.SetLeft(rectangle, i * (size + space));
					//Canvas.SetTop(rectangle, j * (size + space));
				}
			}
		}
	}
}
