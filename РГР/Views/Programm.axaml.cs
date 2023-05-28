using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using DynamicData;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using РГР.Models;
using РГР.ViewModels;
using РГР.Views.Elements;

namespace РГР.Views
{
    public partial class Programm : Window
    {
        private int counter_and = 0, counter_enter = 0, counter_halfsum = 0, counter_not = 0, counter_or = 0, counter_out = 0, counter_xor = 0;
        public Point pointPointerPressed;
        public Point pointerPositionIntoElement;
        public Point startPoint;
        public Point endPoint;
        private Programm programm1;
        public Programm()
        {
            InitializeComponent();
            DataContext = new ProgrammViewModel();
        }

        public object InElements { get; set; }

        public void Exit_programm2(object? sender, CancelEventArgs e)
        {
            this.Close();
        }

        public void Create_Programm1(object sender, RoutedEventArgs eventArgs)
        {
            programm1 = new Programm();
            this.Hide();
            programm1.Show();
            programm1.Closing += Exit_programm2;
        }

        

        public void ButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            if (DataContext is ProgrammViewModel programmViewModel)
            {
                if(sender is Button button)
                {
                    programmViewModel.Take_Button_Name(button.Name); 
                }
            }
        }

        public void MadeScheme(object sender, RoutedEventArgs eventArgs)
        {
            if(DataContext is ProgrammViewModel programmViewModel)
            {
                programmViewModel.Project.Scheme.Add(new Class_Scheme());
            }
        }

        public void DestroyScheme(object sender, RoutedEventArgs eventArgs)
        {
            if(DataContext is ProgrammViewModel programmViewModel)
            {
                if(programmViewModel.Project.Scheme.Count > 0)
                {
                    programmViewModel.Project.Scheme.RemoveAt(programmViewModel.Select_Scheme);
                }
            }
        }


        public void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            pointPointerPressed = pointerPressedEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

            if(DataContext is ProgrammViewModel programm)
            {
                if(programm.Project.Scheme.Count == 0)
                {
                    return;
                }
                if(programm.Button_Number == 1) 
                {
                    programm.Project.Scheme[programm.Select_Scheme].Elements.Add(new Class_And { 
                        Main_Point = pointPointerPressed, 
                        Name = $"element_and{counter_and}",
                    });
                    counter_and += 1;
                }
                else if (programm.Button_Number == 2)
                {
                    programm.Project.Scheme[programm.Select_Scheme].Elements.Add(new Class_Or { 
                        Main_Point = pointPointerPressed,
                        Name = $"element_or{counter_or}",
                    });
                    counter_or += 1;
                }
                else if (programm.Button_Number == 3)
                {
                    programm.Project.Scheme[programm.Select_Scheme].Elements.Add(new Class_Not { 
                        Main_Point = pointPointerPressed,
                        Name = $"element_not{counter_not}",
                    });
                    counter_not += 1;
                }
                else if (programm.Button_Number == 4)
                {
                    programm.Project.Scheme[programm.Select_Scheme].Elements.Add(new Class_XoR { 
                        Main_Point = pointPointerPressed,
                        Name = $"element_xor{counter_xor}"
                    });
                    counter_xor += 1;
                }
                else if (programm.Button_Number == 5)
                {
                    programm.Project.Scheme[programm.Select_Scheme].Elements.Add(new Class_Enter { 
                        Main_Point = pointPointerPressed,
                        Name = $"element_enter{counter_enter}"
                    });
                    counter_enter += 1;
                }
                else if (programm.Button_Number == 6)
                {
                    programm.Project.Scheme[programm.Select_Scheme].Elements.Add(new Class_Out { 
                        Main_Point = pointPointerPressed,
                        Name = $"element_out{counter_out}"
                    });
                    counter_out += 1;
                }
                else if (programm.Button_Number == 7)
                {
                    programm.Project.Scheme[programm.Select_Scheme].Elements.Add(new Class_HalfSum { 
                        Main_Point = pointPointerPressed,
                        Name = $"element_halfsum{counter_halfsum}"
                    });
                    counter_halfsum += 1;
                }
                else if(programm.Button_Number == 0)
                {
                    if(pointerPressedEventArgs.Source is Path shape)
                    {
                        if(shape.DataContext is Full_Elements myElement)
                        {
                            programm.Selected_Element = myElement;
                        }
                        pointerPositionIntoElement = pointerPressedEventArgs.GetPosition(shape);
                        this.PointerMoved += PointerMoveDragElement;
                        this.PointerReleased += PointerPressedReleasedDragElement;
                    }
                    else if(pointerPressedEventArgs.Source is Polygon shape1)
                    {
                        if (shape1.DataContext is Full_Elements myElement)
                        {
                            programm.Selected_Element = myElement;
                        }
                        pointerPositionIntoElement = pointerPressedEventArgs.GetPosition(shape1);
                        this.PointerMoved += PointerMoveDragElement;
                        this.PointerReleased += PointerPressedReleasedDragElement;
                    }
                    else if (pointerPressedEventArgs.Source is Rectangle shape2)
                    { 
                        if (shape2.DataContext is Full_Elements myElement)
                        {
                            programm.Selected_Element = myElement;
                        }
                        pointerPositionIntoElement = pointerPressedEventArgs.GetPosition(shape2);
                        this.PointerMoved += PointerMoveDragElement;
                        this.PointerReleased += PointerPressedReleasedDragElement;
                    }
                    else if (pointerPressedEventArgs.Source is Line line)
                    {
                        if (line.DataContext is Full_Elements myElement)
                        {
                            programm.Selected_Element = myElement;
                        }
                    }
                    else if(pointerPressedEventArgs.Source is Ellipse ellipse)
                    {
                        int index = (int)Char.GetNumericValue(ellipse.Name[ellipse.Name.Length - 1]);
                        startPoint = pointerPressedEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

                        if (ellipse.Name.Contains("out"))
                        {
                            Class_Line l = new Class_Line
                            {
                                StartPoint = startPoint,
                                EndPoint = startPoint,
                                FirstElement = ellipse.DataContext as Full_Elements,
                                SecondElement = null,
                            };

                            l.Ins[index] = new Class_Elements { Element_of_Collection = ellipse.DataContext as Full_Elements };

                            programm.Project.Scheme[programm.Select_Scheme].Elements.Add(l);
                        }
                        else
                        {
                            Class_Line l = new Class_Line
                            {
                                StartPoint = startPoint,
                                EndPoint = startPoint,
                                FirstElement = ellipse.DataContext as Full_Elements,
                                SecondElement = null,
                            };

                            l.Outs[index] = new Class_Elements { Element_of_Collection = ellipse.DataContext as Full_Elements };

                            programm.Project.Scheme[programm.Select_Scheme].Elements.Add(l);
                        }

                        this.PointerMoved += PointerMoveDrawLine;
                        this.PointerReleased += PointerPressedReleasedDrawLine;

                        //startPoint = pointerPressedEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());
                        //programm.All_Elements.Add(new Class_Line { StartPoint = startPoint, EndPoint = startPoint, FirstElement = ellipse.DataContext as Full_Elements, Name1 = Name });
                        //this.PointerMoved += PointerMoveDrawLine;
                        //this.PointerReleased += PointerPressedReleasedDrawLine;
                    }
                }
            }
        }

        private void DoubleTapOnCanvas(object sender, RoutedEventArgs e)
        {
            if (DataContext is ProgrammViewModel viewModel)
            {
                var src = e.Source;
                if (src == null) return;

                if (src is Rectangle rect)
                {
                    if (rect.DataContext is Class_Enter element)
                    {
                        element.Outputs[0] ^= 1;
                        element.Output ^= 1;

                        viewModel.Power(element);
                    }
                }
            }
        }

        public void DoubleTapOnCanvas2(object? sender, RoutedEventArgs e)
        {
            if (DataContext is ProgrammViewModel viewModel)
            {
                if (e.Source is TextBlock textBlock)
                {
                    if (textBlock.DataContext is Class_Scheme scheme)
                    {
                        Class_Scheme? circuitPtr = scheme;
                        Element_DifferName? changeNameWindow = new Element_DifferName(circuitPtr);
                        changeNameWindow.ShowDialog(this);
                    }
                    else if (textBlock.DataContext is Class_Projects project)
                    {
                        Class_Projects? projectPtr = project;
                        Element_DifferName? changeNameWindow = new Element_DifferName(projectPtr);
                        changeNameWindow.ShowDialog(this);
                    }
                }
            }
        }

        public void PointerMoveDragElement(object? sender, PointerEventArgs pointerEventArgs)
        {
            if(pointerEventArgs.Source is Shape shape) 
            {
                Point currentPointPosition = pointerEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

                if(shape.DataContext is Full_Elements myElement)
                {
                    myElement.Main_Point = new Point(
                        currentPointPosition.X - pointerPositionIntoElement.X,
                        currentPointPosition.Y - pointerPositionIntoElement.Y
                        );
                }
            }
        }

        public void PointerPressedReleasedDragElement(object? sender, PointerReleasedEventArgs poiterEventArgs)
        {
            this.PointerMoved -= PointerMoveDragElement;
            this.PointerReleased -= PointerPressedReleasedDragElement;
        }

        public void Exit_programm(object sender, RoutedEventArgs eventArgs)
        {
            this.Close();
        }

        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (DataContext is ProgrammViewModel viewModel)
            {
                Debug.WriteLine(sender);
                Class_Line connector = viewModel.Project.Scheme[viewModel.Select_Scheme].Elements[viewModel.Project.Scheme[viewModel.Select_Scheme].Elements.Count - 1] as Class_Line;
                Point currentPointerPosition = pointerEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

                connector.EndPoint = new Point(
                        currentPointerPosition.X - 1,
                        currentPointerPosition.Y - 1);
            }
        }

        private void PointerPressedReleasedDrawLine(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;

            var canvas = this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false && canvas.Name.Equals("Holst"));

            var coords = pointerReleasedEventArgs.GetPosition(canvas);

            var element = canvas.InputHitTest(coords);
            if (DataContext is ProgrammViewModel viewModel)
            {
                if (element is Ellipse ellipse)
                {
                    if (ellipse.DataContext is Full_Elements element1)
                    {
                        if (viewModel.Project.Scheme[viewModel.Select_Scheme].Elements[viewModel.Project.Scheme[viewModel.Select_Scheme].Elements.Count - 1] is Class_Line line)
                        {
                            if (line.FirstElement != element)
                            {
                                int index2 = (int)Char.GetNumericValue(ellipse.Name[ellipse.Name.Length - 1]);
                                int hasElement = 0;

                                line.SecondElement = element1;

                                for (int i = 0; i < 8; i++)
                                {
                                    if (line.Ins[i] != null)
                                    {
                                        hasElement = 1;
                                        break;
                                    }
                                }

                                if (hasElement != 0)
                                {
                                    for (int index1 = 0; index1 < 8; index1++)
                                    {
                                        if (line.Ins[index1] != null)
                                        {
                                            line.Ins[index1].Number = index2;
                                            line.Outs[index2] = new Class_Elements { Element_of_Collection = element1, Number = index1 };

                                            line.Ins[index1].Element_of_Collection.Outs[index1] = new Class_Elements {Element_of_Collection = element1, Number = index2 };
                                            line.Outs[index2].Element_of_Collection.Ins[index2] = new Class_Elements { Element_of_Collection = line.Ins[index1].Element_of_Collection, Number = index1 };

                                            viewModel.Power(line.Ins[index1].Element_of_Collection);

                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int index1 = 0; index1 < 8; index1++)
                                    {
                                        if (line.Outs[index1] != null)
                                        {
                                            line.Outs[index1].Number = index2;
                                            line.Ins[index2] = new Class_Elements { Element_of_Collection = element1, Number = index1 };

                                            line.Outs[index1].Element_of_Collection.Ins[index1] = new Class_Elements { Element_of_Collection = element1, Number = index2 };
                                            line.Ins[index2].Element_of_Collection.Outs[index2] = new Class_Elements { Element_of_Collection = line.Outs[index1].Element_of_Collection, Number = index1 };

                                            viewModel.Power(line.Ins[index2].Element_of_Collection);

                                            break;
                                        }
                                    }
                                }

                                return;
                            }
                        }
                    }
                }

                viewModel.Project.Scheme[viewModel.Select_Scheme].Elements.RemoveAt(viewModel.Project.Scheme[viewModel.Select_Scheme].Elements.Count - 1);
            }
        }

        public async void SaveFile(object sender, RoutedEventArgs args)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(new FileDialogFilter
            {
                Name = "xml files",
                Extensions = new string[] { "xml" }.ToList()
            });
            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is ProgrammViewModel programmWindowViewModel)
                {
                    programmWindowViewModel.SaveCollection(path);
                }
            }
        }

        public async void LoadFile(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter
            {
                Name = "xml files",
                Extensions = new string[] { "xml" }.ToList()
            });
            
            string[]? path = await openFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is ProgrammViewModel programmWindowViewModel)
                {
                    programmWindowViewModel.LoadCollection(path[0]);
                }
            }
        }

    }
}
