using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 32)
        {
            Invoke("endGame", 2f);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Level1()
    {
        SceneManager.LoadScene(2);
    }
    public void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public void Level3()
    {
        SceneManager.LoadScene(4);
    }
    public void Level4()
    {
        SceneManager.LoadScene(5);
    }
    public void Level5()
    {
        SceneManager.LoadScene(6);
    }
    public void Level6()
    {

        SceneManager.LoadScene(7);
    }
    public void Level7()
    {

        SceneManager.LoadScene(8);
    }
    public void Level8()
    {

        SceneManager.LoadScene(9);
    }
    public void Level9()
    {

        SceneManager.LoadScene(10);
    }
    public void Level10()
    {

        SceneManager.LoadScene(11);
    }
    public void Level11()
    {

        SceneManager.LoadScene(12);
    }
    public void Level12()
    {

        SceneManager.LoadScene(13);
    }
    public void Level13()
    {

        SceneManager.LoadScene(14);
    }
    public void Level14()
    {

        SceneManager.LoadScene(15);
    }
    public void Level15()
    {

        SceneManager.LoadScene(16);
    }
    public void Level16()
    {

        SceneManager.LoadScene(17);
    }
    public void Level17()
    {

        SceneManager.LoadScene(18);
    }
    public void Level18()
    {

        SceneManager.LoadScene(19);
    }
     public void Level19()
    {

        SceneManager.LoadScene(20);
    }
     public void Level20()
    {

        SceneManager.LoadScene(21);
    }
     public void Level21()
    {

        SceneManager.LoadScene(22);
    }
     public void Level22()
    {

        SceneManager.LoadScene(23);
    }
     public void Level23()
    {

        SceneManager.LoadScene(24);
    }
     public void Level24()
    {

        SceneManager.LoadScene(25);
    }
     public void Level25()
    {

        SceneManager.LoadScene(26);
    }
     public void Level26()
    {

        SceneManager.LoadScene(27);
    }
     public void Level27()
    {

        SceneManager.LoadScene(28);
    }
     public void Level28()
    {

        SceneManager.LoadScene(29);
    }
     public void Level29()
    {

        SceneManager.LoadScene(30);
    }
     public void Level30()
    {

        SceneManager.LoadScene(31);
    }
    private void endGame()
    {
        SceneManager.LoadScene(0);
    }
    public void HowToPlay(){
        SceneManager.LoadScene(2);
    }
public void Back(){
    SceneManager.LoadScene(0);
}
}
