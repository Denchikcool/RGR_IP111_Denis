using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using РГР.Models;

namespace РГР.ViewModels
{
    public class ProgrammViewModel : ViewModelBase
    {
        private int button_number;
        private int select_scheme;
        private Class_Projects project;
        private ObservableCollection<Full_Elements> all_elements;
        private Full_Elements selected_element;
        private ObservableCollection<Class_Scheme> scheme_list;
        private string project_name;
        private ObservableCollection<Class_Projects> all_projects;


        public int Button_Number
        {
            get => button_number;
            set => this.RaiseAndSetIfChanged(ref button_number, value);
        }
        public ProgrammViewModel()
        {
            all_elements = new ObservableCollection<Full_Elements>();
            Project = new Class_Projects();
            Project.Scheme.Add(new Class_Scheme());
            All_Elements = Project.Scheme[0].Elements;
        }

        public ObservableCollection<Full_Elements> All_Elements
        {
            get => all_elements;
            set => this.RaiseAndSetIfChanged(ref all_elements, value);
        }

        public Full_Elements Selected_Element
        {
            get => selected_element;
            set => this.RaiseAndSetIfChanged(ref selected_element, value); 
        }

        public ObservableCollection<Class_Projects> All_Projects
        {
            get => all_projects;
            set => this.RaiseAndSetIfChanged(ref all_projects, value); 
        }

        public Class_Projects Project
        {
            get => project;
            set => this.RaiseAndSetIfChanged(ref project, value);
        }

        public ObservableCollection<Class_Scheme> Scheme_List
        {
            get => Project.Scheme;
        }

        public string ProjectName
        {
            get => Project.Project_Name;
        }

        public int Select_Scheme
        {
            get => select_scheme;
            set
            {
                this.RaiseAndSetIfChanged(ref select_scheme, value);
                if(Select_Scheme < 0)
                {
                    Select_Scheme = 0;
                }
                if(Project.Scheme.Count == 0)
                {
                    All_Elements = null;
                }
                else
                {
                    All_Elements = Project.Scheme[Select_Scheme].Elements;
                }
            }
        }


        public void Take_Button_Name(string name)
        {
            if(name == "button1")
            {
                if(Button_Number == 1)
                {
                    Button_Number = 0;
                }
                else if(Button_Number != 1)
                {
                    Button_Number = 1;
                }
            }
            else if (name == "button2")
            {
                if (Button_Number == 2)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 2)
                {
                    Button_Number = 2;
                }
            }
            else if (name == "button3")
            {
                if (Button_Number == 3)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 3)
                {
                    Button_Number = 3;
                }
            }
            else if (name == "button4")
            {
                if (Button_Number == 4)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 4)
                {
                    Button_Number = 4;
                }
            }
            else if (name == "button5")
            {
                if (Button_Number == 5)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 5)
                {
                    Button_Number = 5;
                }
            }
            else if (name == "button6")
            {
                if (Button_Number == 6)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 6)
                {
                    Button_Number = 6;
                }
            }
            else if (name == "button7")
            {
                if (Button_Number == 7)
                {
                    Button_Number = 0;
                }
                else if (Button_Number != 7)
                {
                    Button_Number = 7;
                }
            }
        }

        public void DeleteElement()
        {
            ObservableCollection<Full_Elements> tempCollection = Project.Scheme[Select_Scheme].Elements;

            for (int i = tempCollection.Count - 1; i >= 0; i--)
            {
                if (tempCollection[i] is Full_Elements tempElement)
                {
                    if (tempElement is Class_Line tempLine)
                    {
                        if (tempLine == Selected_Element)
                        {
                            int index1 = 0, index2 = 0;

                            for (int j = 0; j < 8; j++)
                            {
                                if (tempLine.Ins[j] != null)
                                {
                                    tempLine.Ins[j].Element_of_Collection.Outs[j] = null;
                                    index1 = j;
                                }

                                if (tempLine.Outs[j] != null)
                                {
                                    tempLine.Outs[j].Element_of_Collection.Ins[j] = null;
                                    index2 = j;
                                }
                            }

                            Power(tempLine.Outs[index2].Element_of_Collection);
                            tempLine.Ins[index1] = null;
                            tempLine.Outs[index2] = null;
                            Project.Scheme[Select_Scheme].Elements.RemoveAt(i);
                            break;
                        }
                        else
                        {
                            if (tempLine.FirstElement == Selected_Element || tempLine.SecondElement == Selected_Element)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    if (tempLine.Ins[j] != null)
                                    {
                                        tempLine.Ins[j] = null;
                                    }

                                    if (tempLine.Outs[j] != null)
                                    {
                                        tempLine.Outs[j] = null;
                                    }
                                }

                                Project.Scheme[Select_Scheme].Elements.RemoveAt(i);
                            }
                        }
                    }
                    else
                    {
                        if (tempElement == Selected_Element)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (tempElement.Ins[j] != null)
                                {
                                    tempElement.Ins[j].Element_of_Collection.Outs[tempElement.Ins[j].Number] = null;
                                    tempElement.Ins[j] = null;
                                }

                                if (tempElement.Outs[j] != null)
                                {
                                    tempElement.Outs[j].Element_of_Collection.Ins[tempElement.Outs[j].Number] = null;
                                    Power(tempElement.Outs[j].Element_of_Collection);
                                    tempElement.Outs[j] = null;
                                }
                            }

                            Project.Scheme[Select_Scheme].Elements.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        public void SaveCollection(string path)
        {
            var xmlCollectionSaver = new XML_Saver();
            var projectCollectionSaver = new JSON_Saver();
            xmlCollectionSaver.Save(All_Elements, path);
            projectCollectionSaver.Save_project(All_Projects, @"..\..\..\all_proj.json");
        }
        public void LoadCollection(string path)
        {
            var xmlCollectionLoader = new XML_Loader();
            All_Elements = new ObservableCollection<Full_Elements>(xmlCollectionLoader.Load(path));
            Class_Line templines = new Class_Line();
            templines.CheckLines(All_Elements);
        }

        public void Power(Full_Elements element)
        {
            element.Meaning();
            for (int i = 0; i < 8; i++)
            {
                if (element.Outs[i] != null)
                {
                    Power(element.Outs[i].Element_of_Collection);
                }
            }
        }

    }
}
