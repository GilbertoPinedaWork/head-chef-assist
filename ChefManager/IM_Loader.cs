using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChefManager
{
    public sealed class IM_Loader
    {
        public List<Ingredient> IngredientList;

        public IM_Loader(string ingredientFolderPath)
        {
            IngredientList = LoadFromFiles(ingredientFolderPath);
        }

        private static List<Ingredient> LoadFromFiles(string ingredientFolderPath)
        {
            GM_Methods.MakeSureFolderExist(ingredientFolderPath);
            var ingredientFiles = Directory.GetFiles(ingredientFolderPath);

            var ingredientList = new List<Ingredient>();
            if (ingredientFiles.Length <= 0) return ingredientList;

            foreach (var file in ingredientFiles)
            {
                string[] ingredientData = File.ReadAllLines(file).SelectMany(s => s.Split('\t')).ToArray();

                double.TryParse(ingredientData[1], out var cost);
                double.TryParse(ingredientData[2], out var yield);
                int.TryParse(ingredientData[4], out var quantity);

                ingredientList.Add(new Ingredient
                {
                    Name = ingredientData[0],
                    Cost = cost,
                    Yield = yield,
                    Unit = ingredientData[3],
                    Quantity = quantity,
                });

                var descriptionIndex = 5;
                var ingredient = ingredientList.Last();
                do
                {
                    ingredient.Description += ingredientData[descriptionIndex];
                    descriptionIndex++;
                } while (descriptionIndex < ingredientData.Length);
            }

            return ingredientList;
        }

        public static void LoadToFiles(IEnumerable<Ingredient> ingredientList, string folderPath)
        {
            string previous = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(folderPath);

            foreach (var ingredient in ingredientList)
            {
                using (var fileWriter = new StreamWriter(ingredient.Name + ".txt"))
                {
                    fileWriter.WriteLine(ingredient.Name);
                    fileWriter.WriteLine(ingredient.Cost);
                    fileWriter.WriteLine(ingredient.Yield);
                    fileWriter.WriteLine(ingredient.Unit);
                    fileWriter.WriteLine(ingredient.Quantity);
                    fileWriter.WriteLine(ingredient.Description);
                }
            }

            Directory.SetCurrentDirectory(previous);
        }
    }
}