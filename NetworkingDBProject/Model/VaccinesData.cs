//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Text;

//namespace CovidDetail.Models
//{
//    public class VaccinesData: INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler PropertyChanged;

//        [PrimaryKey, AutoIncrement]
//        public int Id { get; set; }

//        private string _Name;

       

//        public string Name {
//            get { return _Name; }
//            set {
//                if(value==_Name)
//                    return;
//                _Name = value;
//                if (PropertyChanged != null)
//                {

//                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
//                }
//            }
//        }
//        public bool Demand { get; set; }
//        public bool InStock { get; set; }

//        public string statusDemand
//        {
//            get
//            {
//                if (Demand)
//                    return "In Demand";
//                else
//                    return "Not In Demand";
//            }
//            set { }
//        }

//        public string statusInStock
//        {
//            get
//            {
//                if (InStock)
//                    return "In Stock";
//                else
//                    return "Out of Stock";
//            }


//            set { }
//        }

//    }
//}
