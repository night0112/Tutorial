using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] animalPrefabs;
    [SerializeField] float spawnRangeX;
    [SerializeField] float spawnPosZ;
    [SerializeField] float spawnInterval;//�����Ԋu
    float elapsedTime;//�o�ߎ���
    void Update()
    {
        elapsedTime += Time.deltaTime;//��F�̎��Ԃ������Ă���...

        //�J�E���g����Ă��鎞�Ԃ����𒴂�����...
        if(elapsedTime > spawnInterval) {
            SpawnRandomAnimal();
            elapsedTime = 0.0f;//�o�ߎ��ԃ��Z�b�g���Ȃ��Ƒ�ʐ��������
        }
    }
    //Update�̉��ɏ����āI�ł��N���X���ɏ����āI�I
    void SpawnRandomAnimal() {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),
                                        0,
                                        spawnPosZ);
        Instantiate(animalPrefabs[animalIndex],
                    spawnPos,
                    animalPrefabs[animalIndex].transform.rotation);

    }
}//�������N���X�̏I���
//�������珑�����Ⴄ�l������...�_��
