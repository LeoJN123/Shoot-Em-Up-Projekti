//Tämä skripti estää materiaalien importoimisen ja uusien materiaalikansioiden luomisen kun importoi 3D meshin projektiin
using UnityEditor;
public class FBXScaleFix : AssetPostprocessor
{
    public void OnPreprocessModel()
    {
        ModelImporter modelImporter = (ModelImporter)assetImporter;
        modelImporter.globalScale = 1;
        modelImporter.importMaterials = false;
    }
}