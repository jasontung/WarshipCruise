using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SwitchBlackWhiteModeCmd : ICommand
{
    public string warshipTag = "Player";
    private NormalGroup normalGroup;
    private BlackWhiteGroup blackWhiteGroup;
    private GameObject warship;
    private Material originalSkybox;
    private List<Material> originalWarshipMaterials = new List<Material>();
    private Renderer[] allRendererAtWarship;
    public Material blackModeWarshipMaterial;

    public enum Mode
    {
        Normal,
        BlackWhite
    }
    public Mode mode;
    public override void Setup()
    {
        warship = GameObject.FindGameObjectWithTag(warshipTag);
        normalGroup = GameObject.FindObjectOfType<NormalGroup>();
        blackWhiteGroup = GameObject.FindObjectOfType<BlackWhiteGroup>();
        originalSkybox = RenderSettings.skybox;
        allRendererAtWarship = warship.GetComponentsInChildren<Renderer>();
        foreach (var renderer in allRendererAtWarship)
        {
            originalWarshipMaterials.Add(renderer.sharedMaterial);
        }
    }

    public override IEnumerator Execute()
    {
        switch (mode)
        {
            case Mode.BlackWhite:
                RenderSettings.skybox = null;
                RenderSettings.fog = false;
                normalGroup.Hide();
                blackWhiteGroup.Show();
                foreach (var renderer in allRendererAtWarship)
                {
                    renderer.sharedMaterial = blackModeWarshipMaterial;
                }
                break;
            case Mode.Normal:
                RenderSettings.skybox = originalSkybox;
                RenderSettings.fog = true;
                normalGroup.Show();
                blackWhiteGroup.Hide();
                for (int i = 0; i < allRendererAtWarship.Length; i++)
                {
                    allRendererAtWarship[i].sharedMaterial = originalWarshipMaterials[i];
                }
                break;
        }
        yield return null;
    }
}
