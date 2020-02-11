using System;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

namespace LaborLog
{
    [XmlRoot("LabLog")]
    public class LabLog
    {
        [XmlElement("MetaInformation")]
        public MetaInformation metaInformation;

        [XmlElement("ColumsData")]
        private ArrayList ColumnData;

        public LabLog()
        {
            ColumnData = new ArrayList();
            metaInformation = new MetaInformation();
            metaInformation.Categories = CategoryClass.setStandard();
        }

        [XmlElement("InfoEntry")]
        public Entry[] InfoEntryItems
        {
            get
            {
                Entry[] items = new Entry[ColumnData.Count];
                ColumnData.CopyTo(items);
                return items;
            }
            set
            {
                if (value == null) return;
                Entry[] items = (Entry[])value;
                ColumnData.Clear();
                foreach (Entry item in items)
                    ColumnData.Add(item);
            }
        }

        public int AddColoumnEntry(Entry item)
        {
            return ColumnData.Add(item);
        }
        public void AddColoumnEntryAt(int i, Entry item)
        {
            ColumnData.Insert(i, item);
        }
        public void RemoveColoumnEntryAt(int i)
        {
            if (i != -1)
                ColumnData.RemoveAt(i);
        }

        public static void insertEntry(ref LabLog labLog, ref Entry _entry, bool edit)
        {
            int tmp = 0;
            insertEntry(ref labLog, ref _entry, edit, out tmp);
        }

        public static void insertEntry(ref LabLog labLog, ref Entry _entry, bool edit,  out int entryNumber)
        {
            entryNumber = -1;
            if (labLog.InfoEntryItems.Length > 1)
            {
                labLog.InfoEntryItems[0].edit = edit;
                DateTime _actual = DateTime.Parse(_entry.StartTime);
                DateTime _start = DateTime.Parse(labLog.InfoEntryItems[0].StartTime);
                DateTime _end = DateTime.Parse(labLog.InfoEntryItems[labLog.InfoEntryItems.Length - 1].StartTime);

                if (_actual < _start) // entry is the youngest one, insert at the begining of the array
                { 
                    entryNumber = 0;
                    labLog.AddColoumnEntryAt(0, _entry);
                }
                else if (_actual >= _start && _actual < _end) // entry is somewhere in betwenn to insert
                { 
                    for (int i = 1; i < labLog.InfoEntryItems.Length; i++)
                    {
                        DateTime dt0 = DateTime.Parse(labLog.InfoEntryItems[i - 1].StartTime);
                        DateTime dt1 = DateTime.Parse(labLog.InfoEntryItems[i].StartTime);

                        if (dt0 <= _actual && _actual < dt1)
                        {
                            entryNumber = i;
                            labLog.AddColoumnEntryAt(i, _entry);
                            break;
                        }
                    }
                }
                else if (_actual >= _end) // entry is the oldest one, insert at the end of the array
                {
                    labLog.AddColoumnEntry(_entry);
                    entryNumber = labLog.InfoEntryItems.Length - 1;
                }
            }
            else
            {
                labLog.AddColoumnEntry(_entry);
                entryNumber = labLog.InfoEntryItems.Length - 1;
            }
        }

        public static LabLog deserialisieren(string _dbPath)
        {
            XmlSerializer s = new XmlSerializer(typeof(LabLog));
            LabLog _records;
            TextReader r = new StreamReader(_dbPath);
            _records = (LabLog)s.Deserialize(r);
            r.Close();

            // set user
            System.Collections.Generic.List<UsersClass> users = new System.Collections.Generic.List<UsersClass>();
            for (int i = 0; i < _records.metaInformation.Users.Length; i++)
                users.Add(new UsersClass(_records.metaInformation.Users[i], true));

            for (int i = 0; i < _records.InfoEntryItems.Length; i++)
            {
                for (int j = 0; j < _records.InfoEntryItems[i].Users.Length; j++)
                {
                    bool existent = false;
                    for (int k = 0; k < users.Count; k++)
                    {
                        if (users[k].Name == _records.InfoEntryItems[i].Users[j])
                            existent = true;
                    }
                    if (!existent)
                        users.Add(new UsersClass(_records.InfoEntryItems[i].Users[j], false));

                }
            }
            _records.metaInformation.AllUsers = users.ToArray();

            // set categories
            System.Collections.Generic.List<CategoryClass> categories = new System.Collections.Generic.List<CategoryClass>(_records.metaInformation.Categories);

            for (int i = 0; i < _records.InfoEntryItems.Length; i++)
            {
                bool existent = false;
                for (int k = 0; k < categories.Count; k++)
                {
                    if (categories[k].Name == _records.InfoEntryItems[i].Category.Name)
                        existent = true;
                }
                if (!existent)
                {
                    categories.Add(new CategoryClass(_records.InfoEntryItems[i].Category.Name,
                                                      _records.InfoEntryItems[i].Category.UsedForNotfication,
                                                      false));
                }
            }
            _records.metaInformation.Categories = categories.ToArray();

            System.Collections.Generic.List<string> allCategories = new System.Collections.Generic.List<string>();
            foreach (CategoryClass cc in _records.metaInformation.Categories)
                allCategories.Add(cc.Name);
            for (int i = 0; i < _records.InfoEntryItems.Length; i++)
            {
                    if (!allCategories.Contains(_records.InfoEntryItems[i].Category.Name))
                        allCategories.Add(_records.InfoEntryItems[i].Category.Name);
            }
            _records.metaInformation.Users = null;

            return _records;
        }

        public static void serialisieren(LabLog _records, string _dbPath)
        {
            // set users 
            System.Collections.Generic.List<UsersClass> users =
                new System.Collections.Generic.List<UsersClass>(_records.metaInformation.AllUsers);

            _records.metaInformation.Users = null;

            System.Collections.Generic.List<string> userstrings = new System.Collections.Generic.List<string>();
            for (int i = 0; i < users.Count; i++)
                if(users[i].Active)
                    userstrings.Add(users[i].Name);

            _records.metaInformation.Users = userstrings.ToArray();

            // set categories 
            System.Collections.Generic.List<CategoryClass> categories =
                new System.Collections.Generic.List<CategoryClass>(_records.metaInformation.Categories);

            _records.metaInformation.Categories = null;
            System.Collections.Generic.List<CategoryClass> categorieslist =
                new System.Collections.Generic.List<CategoryClass>();

            for (int i = 0; i < categories.Count; i++)
                if (categories[i].Active)
                    categorieslist.Add(categories[i]);

            _records.metaInformation.Categories = categorieslist.ToArray();

            // serialize
            XmlSerializer s = new XmlSerializer(typeof(LabLog));
            TextWriter w = new StreamWriter(_dbPath);
            s.Serialize(w, _records);
            w.Close();
        }
    }

    public class MetaInformation
    {
        [XmlElement("Password")]
        public string Password = null;

        [XmlElement("UsePassword")]
        public bool UsePassword = false;

        [XmlElement("Users")]
        public string[] Users;
        
        [XmlIgnore()]
        public UsersClass[] AllUsers;

        [XmlElement("Categories")]
        public CategoryClass[] Categories;

        public MetaInformation()
        { }
    }

    public class UsersClass
    {
        [XmlIgnore()]
        public bool Active = true;

        [XmlAttribute("Name")]
        public string Name = null;

        public UsersClass()
        { }

        public UsersClass(string Name, bool Active)
        {
            this.Name = Name;
            this.Active = Active;
        }
    }

    public class CategoryClass
    {
        [XmlIgnore()]
        public bool Active = true;

        [XmlAttribute("Name")]
        public string Name = null;

        [XmlAttribute("UsedForNotfication")]
        public bool UsedForNotfication = false;

        public CategoryClass()
        {
            
        }

        public CategoryClass(string Name, bool UsedForNotfication, bool Active)
        {
            this.Active = Active;
            this.Name = Name;
            this.UsedForNotfication = UsedForNotfication;
        }

        public static CategoryClass[] setStandard()
        {
            return new CategoryClass[] 
            {
                new CategoryClass("Maintenance",true, true), 
                new CategoryClass("Inspection",false, true)
            };
        }
    }

    public class Entry
    {
        [XmlElement("StartTime")]
        public string StartTime;
        
        [XmlElement("Duration")]
        public string Duration;
       
        [XmlElement("Category")]
        public CategoryClass Category = null;

        [XmlAttribute("UsedForNotfication")]
        public string NotificationSendAt = null;

        [XmlElement("Users")]
        public string[] Users = null;
       
        [XmlElement("InfoString")]
        public string[] InfoString = null;

        [XmlIgnore()]
        public bool edit = false;

        [XmlIgnore()]
        public bool modified = false;


        [XmlElement("ShowEntry")]
        public bool ShowEntry = true;

        [XmlIgnore()]
        public int runningIndex = -1;

        public Entry()
        {
        }

        public Entry(string starttime, string duration, CategoryClass category, string[] _users, string[] _infostring)
        {
            this.StartTime = starttime;
            this.Duration = duration;

            this.Category = category;
            this.Users = _users;

            this.InfoString = _infostring;
        }
    }
}
