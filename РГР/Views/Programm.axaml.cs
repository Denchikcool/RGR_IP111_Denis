﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using System.Diagnostics;
using System.Linq;
using РГР.Models;
using РГР.ViewModels;

namespace РГР.Views
{
    public partial class Programm : Window
    {
        public Point pointPointerPressed;
        public Point pointerPositionIntoElement;
        public Point startPoint;
        public Point endPoint;
        public Programm()
        {
            InitializeComponent();
            DataContext = new ProgrammViewModel();
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

        public void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            pointPointerPressed = pointerPressedEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

            if(this.DataContext is ProgrammViewModel programm)
            {
                if(programm.Button_Number == 1) 
                {
                    programm.All_Elements.Add(new Class_And { Main_Point = pointPointerPressed });

                    //this.PointerMoved += PointerMoveDrawAnd;
                    //this.PointerReleased += PointerPressedReleasedDrawAnd;
                    //programm.Button_Number = 1;
                }
                else if (programm.Button_Number == 2)
                {
                    programm.All_Elements.Add(new Class_Or { Main_Point = pointPointerPressed });
                }
                else if (programm.Button_Number == 3)
                {
                    programm.All_Elements.Add(new Class_Not { Main_Point = pointPointerPressed });
                }
                else if (programm.Button_Number == 4)
                {
                    programm.All_Elements.Add(new Class_XoR { Main_Point = pointPointerPressed });
                }
                else if (programm.Button_Number == 5)
                {
                    programm.All_Elements.Add(new Class_Enter { Main_Point = pointPointerPressed });
                }
                else if (programm.Button_Number == 6)
                {
                    programm.All_Elements.Add(new Class_Out { Main_Point = pointPointerPressed });
                }
                else if (programm.Button_Number == 7)
                {
                    programm.All_Elements.Add(new Class_HalfSum { Main_Point = pointPointerPressed });
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
                    else if(pointerPressedEventArgs.Source is Ellipse ellipse)
                    {
                        startPoint = pointerPressedEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());
                        //endPoint = pointerPressedEventArgs.GetPosition(ellipse);
                        programm.All_Elements.Add(new Class_Line { StartPoint = startPoint, FirstElement = ellipse.DataContext as Full_Elements });
                        this.PointerMoved += PointerMoveDrawLine;
                        this.PointerReleased += PointerPressedReleasedDrawLine;
                    }
                }
            }
        }

        //public void PointerMoveDrawAnd(object? sender, PointerEventArgs pointerEventArgs)
        //{
        //    if(this.DataContext is ProgrammViewModel programm)
        //    {
        //        Class_And editAnd = new Class_And { Main_Point = pointPointerPressed };
        //        programm.all_elements.Add((Class_And)editAnd);
        //        Point currentPointPosition = pointerEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());
        //    }
        //}

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


        //public void PointerPressedReleasedDrawAnd(object? sender, PointerReleasedEventArgs poiterEventArgs)
        //{
        //    this.PointerMoved -= PointerMoveDrawAnd;
        //    this.PointerReleased -= PointerPressedReleasedDrawAnd;
        //}

        public void Exit_programm(object sender, RoutedEventArgs eventArgs)
        {
            this.Close();
        }

        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is ProgrammViewModel viewModel)
            {
                Debug.WriteLine(sender);
                Class_Line connector = viewModel.All_Elements[viewModel.All_Elements.Count - 1] as Class_Line;
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
            ProgrammViewModel viewModel = this.DataContext as ProgrammViewModel;

            if (element is Ellipse ellipse)
            {
                
                if (ellipse.DataContext is Full_Elements full_element)
                {
                    Class_Line connector = viewModel.All_Elements[viewModel.All_Elements.Count - 1] as Class_Line;
                    connector.SecondElement = full_element;
                    return;
                }
            }

            viewModel.All_Elements.RemoveAt(viewModel.All_Elements.Count - 1);
        }

    }
}
