using System;
using System.Collections.Generic;
using System.IO;
namespace  ChefManager
{
    public class IM_Modifier
    {
      public static void Action(int answer, List<IngredientInfo> ingredientList)
        { 
            switch (answer)
            {
             case 1:
                {
                    ingredientList.Add(IM_PublicInterface.InputAddIngredientProperties());
                    ingredientList.Sort();
                    break;
                }
             case 2:
              {
                IM_PublicInterface.ShowListOnScreen(ingredientList);
                
                string ingredientId = IM_PublicInterface.InputDeleteIngredient();
                int id = GM_Methods.NumberOnlyInput(ingredientId,ingredientList.Count-1) -1;
                
                DeleteIngredient(ingredientList,id);
                break;
              }
             case 3:
                {
                IM_PublicInterface.ShowListOnScreen(ingredientList);
                
                string ingredientId = IM_PublicInterface.InputModifyIngredient();
                int id = GM_Methods.NumberOnlyInput(ingredientId,ingredientList.Count-1) -1;

                IM_PublicInterface.InputAddIngredientProperties(true);
                    break;
                }
                case 4:
                {
                 IM_PublicInterface.ShowListOnScreen(ingredientList);
                 
                 string ingredientId = IM_PublicInterface.InputShowIngredient();
                 int id = GM_Methods.NumberOnlyInput(ingredientId,ingredientList.Count - 1) - 1;
                 
                 IM_PublicInterface.ShowIngredientDetails(ingredientList[id-1]);
                    break;
                }
                case 0:
                    break;
                default:
                {
                   return;
                }
            }
        }
      
      private static void DeleteIngredient(IList<IngredientInfo> list,int id)
      {
         list.RemoveAt(id);
      }
    }
}