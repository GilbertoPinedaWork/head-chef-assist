using System;
using System.Collections.Generic;
namespace  ChefManager
{
    public static class IM_Modifier
    {
      private static void SetName(ref Ingredient ingredient)
      {
         ingredient.Name = IM_PublicInterface.InputName();
      }
      private static void SetDescription(ref Ingredient ingredient)
      {
          ingredient.Description = IM_PublicInterface.InputDescription();
      }
      private static void SetYield(ref Ingredient ingredient)
      {
          ingredient.Yield = IM_PublicInterface.InputYield();
      }
      private static void SetCost(ref Ingredient ingredient)
      {
          ingredient.Cost = IM_PublicInterface.InputCost();
      }
      private static void SetUnit(ref Ingredient ingredient)
      {
          ingredient.Unit = IM_PublicInterface.InputUnit();
      }
      private static void SetIngredientInfo(ref Ingredient ingredient)
      {
        SetName(ref ingredient);
        SetDescription(ref ingredient);
        SetUnit(ref ingredient);
        SetCost(ref ingredient);
        SetYield(ref ingredient);
        
      }
      public static void Action(int answer, ref List<Ingredient> ingredientList)
      { 
          switch (answer)
          {
              case 1:
              {
                  var ingredient = new Ingredient();
                  SetIngredientInfo(ref ingredient);
                  ingredientList.Add(ingredient);
                 // ingredientList.Sort();
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

                  var ingredientInfo = ingredientList[id];
                  SetIngredientInfo(ref ingredientInfo);
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
      private static void DeleteIngredient(IList<Ingredient> list,int id)
      {
         list.RemoveAt(id);
      }
    }
}