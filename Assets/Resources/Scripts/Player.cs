using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Animator animator = null;
    public AudioClip[] audioEffect = null;
    public WordKor wordKorPrefab = null;
    public Canvas canvas = null;

    private const float gravity = -9.8f;
    private Vector3 gravityVector = Vector3.zero;
    private bool m_isJump = false;

    private AudioSource audio = null;
    private int audioCount = 0;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        audio.loop = false;

        audioCount = audioEffect.Length;
    }
    
    void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
            direction.x += 5.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction.x -= 5.0f;

        if (Input.GetKey(KeyCode.DownArrow))
            animator.SetBool("Spin", true);
        else
            animator.SetBool("Spin", false);

        if (!m_isJump && Input.GetKeyDown(KeyCode.Space))
        {
            m_isJump = true;
            gravityVector.y = 5.0f;
        }

        transform.position += direction * Time.deltaTime;

        if (transform.position.x < -5.35f)
            transform.position = new Vector3(-5.35f, transform.position.y);
        else if (transform.position.x > 5.35f)
            transform.position = new Vector3(5.35f, transform.position.y);

        if (m_isJump)
            Gravity();
    }

    private void Gravity()
    {
        gravityVector.y += gravity * Time.deltaTime;
        transform.position += gravityVector * Time.deltaTime;

        if (transform.position.y <= -1.31f)
        {
            transform.position = new Vector3(transform.position.x, -1.31f);
            m_isJump = false;
        }
    }

    private void GetWord(string str)
    {
        WordKor wordKor = Instantiate<WordKor>(wordKorPrefab, canvas.transform);
        wordKor.SetText(str);
        wordKor.transform.position = new Vector3(transform.position.x, transform.position.y, wordKor.transform.position.z);
    }

    private void AudioEffect()
    {
        System.Random random = new System.Random();
        int r = random.Next(0, audioCount);

        audio.clip = audioEffect[r];
        audio.Play();
    }
}
