using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototyp.Entities
{
    static class DrinkWalkMap
    {
        private static List<Entity> entitys = new List<Entity>();
        private static Entity bar;
        private static Entity table;
        private static Entity drink;

        public static List<Entity> createEntitys()
        {
            entitys.Add(new TableWithPersons(880, 320, 150));
            entitys.Add(new TableWithPersons(800, 150, 150));
            entitys.Add(new TableWithPersons(600, 100, 150));
            entitys.Add(new TableWithPersons(400, 100, 150));
            entitys.Add(new TableWithPersons(200, 100, 150));
            entitys.Add(new TableWithPersons(100, 300, 150));
            entitys.Add(new TableWithPersons(320, 550, 150));
            entitys.Add(new TableWithPersons(450, 350, 150));
            entitys.Add(new TableWithPersons(580, 550, 150));

            return entitys;
        }

        public static Entity createBar()
        {
            bar = new Bar(940, 520, 150, 230);
            return bar;
        }
        public static Entity createTable()
        {
            table = new Entities.EmptyTable(100, 550, 150);
            return table;
        }
        public static Entity createDrink()
        {
            drink = new Drink(900, 480, 20);
            return drink;
        }
    }
}
