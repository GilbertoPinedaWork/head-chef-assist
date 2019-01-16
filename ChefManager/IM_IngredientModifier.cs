using System;
using System.Collections.Generic;
using System.IO;
namespace  ChefManager
{
    public sealed class IM_Modifier
    {
     

      private static void SetName(IngredientInfo ingredient)
      {
         ingredient.Name = IM_PublicInterface.InputName();
      }
      private static void SetDescription(IngredientInfo ingredient)
      {
          ingredient.Description = IM_PublicInterface.InputDescription();
      }
      private static void SetYield(IngredientInfo ingredient)
      {
          ingredient.Yield = IM_PublicInterface.InputYield();
      }
      private static void SetCost(IngredientInfo ingredient)
      {
          ingredient.Cost = IM_PublicInterface.InputCost();
      }
      private static void SetUnit(IngredientInfo ingredient)
      {
          ingredient.Unit = IM_PublicInterface.InputUnit();
      }

      private static IngredientInfo SetIngredientInfo(IngredientInfo ingredient)
      {
        SetName(ingredient);
        SetDescription(ingredient);
        SetUnit(ingredient);
        SetCost(ingredient);
        SetYield(ingredient);
        return ingredient;
      }
      public static void Action(int answer, List<IngredientInfo> ingredientList)
      { 
          switch (answer)
          {
              case 1:
              {
                  var ingredient = new IngredientInfo();
                  ingredient = SetIngredientInfo(ingredient);
                  ingredientList.Add(ingredient);
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
                  ingredientList[id] = SetIngredientInfo(ingredientList[id]);
                  ingredientList[id].ToFile();
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