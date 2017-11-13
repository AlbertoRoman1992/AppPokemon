using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appPokemon.Models
{
    class GlobalGrid
    {
        public static Grid gridBattlePage { get; set; }

        public static Grid gridEnemyPokemon { get; set; }
        public static Grid gridBattle { get; set; }
        public static Grid gridFriendPokemon { get; set; }
        public static Grid gridMenu { get; set; }

        public static Label labelHpTitle { get; set; }

        public static Grid gridEnemyData { get; set; }
        public static Image imageEnemyImage { get; set; }

        public static Grid gridEnemyValues { get; set; }
        public static ProgressBar progressBarEnemyXp { get; set; }

        public static Label labelEnemyName { get; set; }
        public static Label labelEnemyLevel { get; set; }
        public static Grid gridEnemyHp { get; set; }

        public static ProgressBar progressBarEnemyHpBar { get; set; }
        public static Label labelEnemyHpData { get; set; }

        public static Grid gridFriendData { get; set; }
        public static Image imageFriendImage { get; set; }

        public static Grid gridFriendValues { get; set; }
        public static ProgressBar progressBarFriendXp { get; set; }

        public static Label labelFriendName { get; set; }
        public static Label labelFriendLevel { get; set; }
        public static Grid gridFriendHp { get; set; }

        public static ProgressBar progressBarFriendHpBar { get; set; }
        public static Label labelFriendHpData { get; set; }

        public static Label labelInfo { get; set; }
        public static Grid gridAttack { get; set; }

        public static Button buttonAttack1 { get; set; }
        public static Button buttonAttack2 { get; set; }
        public static Button buttonAttack3 { get; set; }
        public static Button buttonAttack4 { get; set; }

        public static void InicializarGrids()
        {
            gridBattlePage = new Grid();

            gridEnemyPokemon = new Grid();
            gridBattle = new Grid();
            gridFriendPokemon = new Grid();
            gridMenu = new Grid();

            labelHpTitle = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.End,
                FontSize = 8
            };

            gridEnemyData = new Grid();
            imageEnemyImage = new Image();

            gridEnemyValues = new Grid();
            progressBarEnemyXp = new ProgressBar();

            labelEnemyName = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };
            labelEnemyLevel = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };
            gridEnemyHp = new Grid();

            progressBarEnemyHpBar = new ProgressBar();
            labelEnemyHpData = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            gridFriendData = new Grid();
            imageFriendImage = new Image();

            gridFriendValues = new Grid();
            progressBarFriendXp = new ProgressBar();

            labelFriendName = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };
            labelFriendLevel = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };
            gridFriendHp = new Grid();

            progressBarFriendHpBar = new ProgressBar();
            labelFriendHpData = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 8
            };

            labelInfo = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Gray
            };
            gridAttack = new Grid();

            buttonAttack1 = new Button
            {
                FontSize = 10,
                Text = "Null",
                StyleId = "0"
            };
            buttonAttack2 = new Button
            {
                FontSize = 10,
                Text = "Null",
                StyleId = "1"
            };
            buttonAttack3 = new Button
            {
                FontSize = 10,
                Text = "Null",
                StyleId = "2"
            };
            buttonAttack4 = new Button
            {
                FontSize = 10,
                Text = "Null",
                StyleId = "3"
            };
        }

        public static void DimensionarGrids()
        {
            gridBattlePage.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2.5, GridUnitType.Star) });
            gridBattlePage.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridBattlePage.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2.5, GridUnitType.Star) });
            gridBattlePage.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1.5, GridUnitType.Star) });

            gridEnemyPokemon.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridEnemyPokemon.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });

            gridEnemyData.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            gridEnemyData.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridEnemyData.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });

            gridEnemyValues.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridEnemyValues.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridEnemyValues.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridEnemyValues.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            gridEnemyHp.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridEnemyHp.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            
            gridFriendPokemon.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            gridFriendPokemon.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            gridFriendData.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
            gridFriendData.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            gridFriendData.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            gridFriendValues.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridFriendValues.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridFriendValues.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridFriendValues.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            gridFriendHp.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridFriendHp.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            
            gridMenu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridMenu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            gridAttack.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridAttack.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridAttack.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridAttack.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

        }

        public static void EstructurarGrids()
        {
            gridBattlePage.Children.Add(gridEnemyPokemon, 0, 0);
            gridBattlePage.Children.Add(gridBattle, 0, 1);
            gridBattlePage.Children.Add(gridFriendPokemon, 0, 2);
            gridBattlePage.Children.Add(gridMenu, 0, 3);
            
            gridEnemyPokemon.Children.Add(gridEnemyData, 0, 0);
            gridEnemyPokemon.Children.Add(imageEnemyImage, 1, 0);

            gridEnemyData.Children.Add(gridEnemyValues, 0, 0);
            gridEnemyData.Children.Add(progressBarEnemyXp, 0, 1);

            gridEnemyValues.Children.Add(labelEnemyName, 0, 0);
            gridEnemyValues.Children.Add(labelEnemyLevel, 1, 0);
            gridEnemyValues.Children.Add(labelHpTitle, 0, 1);
            gridEnemyValues.Children.Add(gridEnemyHp, 1, 1);

            gridEnemyHp.Children.Add(progressBarEnemyHpBar, 0, 0);
            gridEnemyHp.Children.Add(labelEnemyHpData, 0, 1);

            gridFriendPokemon.Children.Add(imageFriendImage, 0, 0);
            gridFriendPokemon.Children.Add(gridFriendData, 1, 0);

            gridFriendData.Children.Add(gridFriendValues, 0, 1);
            gridFriendData.Children.Add(progressBarFriendXp, 0, 2);

            gridFriendValues.Children.Add(labelFriendName, 0, 0);
            gridFriendValues.Children.Add(labelFriendLevel, 1, 0);
            gridFriendValues.Children.Add(labelHpTitle, 0, 1);
            gridFriendValues.Children.Add(gridFriendHp, 1, 1);

            gridFriendHp.Children.Add(progressBarFriendHpBar, 0, 0);
            gridFriendHp.Children.Add(labelFriendHpData, 0, 1);

            gridMenu.Children.Add(labelInfo, 0, 0);
            gridMenu.Children.Add(gridAttack, 1, 0);

            gridAttack.Children.Add(buttonAttack1, 0, 0);
            gridAttack.Children.Add(buttonAttack2, 1, 0);
            gridAttack.Children.Add(buttonAttack3, 0, 1);
            gridAttack.Children.Add(buttonAttack4, 1, 1);
        }
    }
}
