using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TutorialManager : MonoBehaviour
{
    public int tutorialStage = 0;

    private string tut0Text = "Chào mừng đến với Farming Madness! Đây là màn hướng dẫn giúp bạn làm quen với những điều cơ bản của trò chơi. Mỗi người chơi sẽ có một phím tương tác riêng. \n Người chơi 1: Nhấn phím E, Người chơi 2: Nhấn phím O.";

    private string tut1Text = "Bạn có thể gieo hạt bằng phím tương tác. Cả hai người đều có thể nhặt hạt giống từ túi hạt được đánh dấu. \n Cả hai: Nhặt một hạt giống.";

    private string tut2Text = "Tuyệt vời! Cả hai bạn đang cầm hạt giống trên tay. Hãy trồng chúng xuống ruộng bằng phím tương tác. \n Cả hai: Trồng hạt giống.";

    private string tut3Text = "Cả hai đã gieo hạt xong. Nhưng chúng chỉ có thể phát triển khi được tưới nước! Một người hãy sử dụng bình tưới để tưới hạt giống.";

    private string tut4Text = "Sau khi được tưới nước, hạt giống sẽ cần một chút thời gian để phát triển và có thể thu hoạch. \n Cả hai: Thu hoạch nông sản.";

    private string tut5Text = "Bạn có thể bán nông sản cho khách hàng. Việc phục vụ khách sẽ giúp bạn ghi điểm, tùy theo độ khó của món hàng và tốc độ hoàn thành. \n Cả hai: Bán nông sản.";

    private string tut6Text = "Khách hàng sẽ chỉ chờ trong một khoảng thời gian nhất định, tuỳ vào đơn hàng của họ. Bạn có thể thấy thời gian còn lại và mức độ hài lòng ở góc trên bên trái. \n Cả hai: Nhấn phím tương tác để tiếp tục.";

    private string tut7Text = "Khi thanh thời gian cạn hết, khách hàng sẽ rời đi và bạn sẽ không thể hoàn thành đơn hàng đó. Một khách mới sẽ đến thay thế. \n Cả hai: Nhấn phím tương tác để tiếp tục.";

    private string tut8Text = "Đôi khi khách hàng muốn mua những món phức tạp hơn là chỉ một loại nông sản. Có nhiều khu vực trên bản đồ sẽ tạo ra các nguyên liệu khác nhau. \n Cả hai: Nhấn phím tương tác để tiếp tục.";

    private string tut9Text = "Ngoài ra còn có thể sản xuất phô mai nhờ tới nhà máy sữa \n Cả hai: Đặt sữa vào nhà sữa để tạo phô mai.";

    private string tut10Text = "Chúc may mắn! Và đừng quên phối hợp đồng đội! \n Cả hai: Nhấn phím tương tác để tiếp tục.";

    private string tut11Text = "Cám ơn bạn đã tham gia trò chơi \n Cả hai: Nhấn phím tương tác để tiếp tục.";




    public GameObject stage1Fence; //Seedbag
    public GameObject stage2Fence; //Field
    public GameObject stage5Fence; //Customer
    public GameObject stage9Fence; //Production Building

    public Text text;

    public GameObject p1Checked;
    public GameObject p2Checked;

    public PlayerInteraction p1;
    public PlayerInteraction p2;

    public Field field1;
    public Field field2;

    public Product milk;
    private bool milkSet = false;

    public SpriteOutline seedbagShader;
    public SpriteOutline fieldShader;
    public SpriteOutline fieldShader2;
    public SpriteOutline canShader;
    //public SpriteOutline customerShader;
    public SpriteOutline itemspawnShader1;
    public SpriteOutline itemspawnShader2;
    public SpriteOutline bakeryShader;

    private bool p1Interaction = false;
    private bool p2Interaction = false;

    public static Action CustomerStart;
    public static Action<int> CustomerEnd;


    private void Start()
    {
        text.text = "";
        p1Checked.SetActive(false);
        p2Checked.SetActive(false);
        AudioManager.instance.Play("theme");
    }

    private void Update()
    {
        if (tutorialStage == 0)
        {
            text.text = tut0Text;
            bool done = WaitForInteractionKeys();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 1)
        {
            text.text = tut1Text;
            stage1Fence.SetActive(false);
            seedbagShader.outlineSize = 2;
            bool done = WaitForCropPickup();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 2)
        {
            text.text = tut2Text;
            stage2Fence.SetActive(false);
            seedbagShader.outlineSize = 0;
            fieldShader.outlineSize = 2;
            fieldShader2.outlineSize = 2;
            bool done = WaitForCropPutdown();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 3)
        {
            text.text = tut3Text;
            stage1Fence.SetActive(true);
            fieldShader.outlineSize = 0;
            fieldShader2.outlineSize = 0;
            canShader.outlineSize = 2;
            bool done = WaitForWatering();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 4)
        {
            text.text = tut4Text;
            canShader.outlineSize = 0;
            bool done = WaitForCropPickup();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 5)
        {
            text.text = tut5Text;
            stage5Fence.SetActive(false);
            bool done = WaitForCropPutdown();

            if (CustomerStart != null)
                CustomerStart();

            if (done)
            {
                NextStage();

                if (CustomerEnd != null)
                    CustomerEnd(1);
            }
        }
        else if (tutorialStage == 6)
        {
            text.text = tut6Text;
            stage2Fence.SetActive(true);
            bool done = WaitForInteractionKeys();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 7)
        {
            text.text = tut7Text;
            bool done = WaitForInteractionKeys();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 8)
        {
            text.text = tut8Text;
            itemspawnShader1.outlineSize = 2;
            itemspawnShader2.outlineSize = 2;
            bool done = WaitForInteractionKeys();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 9)
        {
            text.text = tut9Text;
            stage9Fence.SetActive(false);
            itemspawnShader1.outlineSize = 0;
            itemspawnShader2.outlineSize = 0;
            bakeryShader.outlineSize = 6;
            if (!milkSet)
            {
                p1.SetProduct(milk);
                p2.SetProduct(milk);
                milkSet = true;
            }
            bool done = WaitForProductPutdown();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 10)
        {
            text.text = tut10Text;
            bakeryShader.outlineSize = 0;
            stage5Fence.SetActive(true);
            bool done = WaitForInteractionKeys();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 11)
        {
            text.text = tut11Text;
            bool done = WaitForInteractionKeys();

            if (done)
            {
                NextStage();
            }
        }
        else if (tutorialStage == 12)
        {
            StartCoroutine(NextLevel());
        }
        
    }

    private void NextStage()
    {
        tutorialStage++;
        p1Interaction = false;
        p2Interaction = false;
        p1Checked.SetActive(false);
        p2Checked.SetActive(false);
    }

    private IEnumerator NextLevel()
    {
        AudioSource s = AudioManager.instance.GetAudioSource("theme");
        AudioFadeOut.FadeOut(s, 2);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("PlayerSelection");
    }

    private bool WaitForInteractionKeys()
    {
        if (Input.GetKeyDown(p1.keyInteract))
        {
            p1Interaction = true;
            p1Checked.SetActive(true);
        }
        if (Input.GetKeyDown(p2.keyInteract))
        {
            p2Interaction = true;
            p2Checked.SetActive(true);
        }
        return p1Interaction && p2Interaction;
    }

    private bool WaitForCropPickup()
    {
        if (p1.GetCrop() != null)
        {
            p1Interaction = true;
            p1Checked.SetActive(true);
        }
        if (p2.GetCrop() != null)
        {
            p2Interaction = true;
            p2Checked.SetActive(true);
        }
        return p1Interaction && p2Interaction;
    }

    private bool WaitForCropPutdown()
    {
        if (p1.GetCrop() == null)
        {
            p1Interaction = true;
            p1Checked.SetActive(true);
        }
        if (p2.GetCrop() == null)
        {
            p2Interaction = true;
            p2Checked.SetActive(true);
        }
        return p1Interaction && p2Interaction;
    }

    private bool WaitForWatering()
    {
        if (field1.GetIsWet())
        {
            p1Interaction = true;
            p1Checked.SetActive(true);
        }
        if (field2.GetIsWet())
        {
            p2Interaction = true;
            p2Checked.SetActive(true);
        }
        return p1Interaction && p2Interaction;
    }

    private bool WaitForProductPutdown()
    {
        if (p1.GetProduct() == null)
        {
            p1Interaction = true;
            p1Checked.SetActive(true);
        }
        if (p2.GetProduct() == null)
        {
            p2Interaction = true;
            p2Checked.SetActive(true);
        }
        return p1Interaction && p2Interaction;
    }
}
