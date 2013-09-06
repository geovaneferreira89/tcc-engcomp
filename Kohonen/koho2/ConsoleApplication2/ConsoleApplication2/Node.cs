using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Node
    {

        int m_weights_number;               //number of weights
        float[] m_weights;                  //weights vector
        float[] m_coords;                   //x,y,z, ... M_DIM position
        int m_class;                        //class mark 0-undetermined, 1,2,3,....
        float m_precision;                  //(max class votes)/(class1 votes + class2 votes + ... + classN votes)
        int[] m_votes;                      //votes for class1, class2, ... classN  //actual classes numbers stored in REC->clsnum[] array

        //Construtor

        public float[] get_coords()
        {
            return m_coords;
        }

        public float[] get_weights() 
        {
            return m_weights;
        }

        public float get_precision() 
        {
            return m_precision;
        }

        public void train(float[] vec, float learning_rule)
        {
            for (int w = 0; w < m_weights_number; w++)
                    m_weights[w] += learning_rule * (vec[w] - m_weights[w]);
        }

        public float get_distance(float[] vec) 
        {
            float distance = 0.0f;
            float n1 = 0.0f, n2 = 0.0f;
              
            //euclidian
            if (m_weights_number >= 4) {
                    distance = mse(vec, m_weights, m_weights_number);
            } else {
                    for (int w = 0; w < m_weights_number; w++)
                            distance += (vec[w] - m_weights[w]) * (vec[w] - m_weights[w]);
            }
            return Math.Sqrt( System.Convert.ToDouble(distance) );                    
        }

        //Mean Square Error
        public float mse(float[] vec1, float[] vec2, int size)
        {
            float z = 0.0f, fres = 0.0f;
            //float ftmp[4];
            float[] ftmp = new float[4];

            __m128 mv1, mv2, mres;
            mres = _mm_load_ss(&z);

            for (int i = 0; i < size / 4; i++) {
                    mv1 = _mm_loadu_ps(&vec1[4*i]);
                    mv2 = _mm_loadu_ps(&vec2[4*i]);
                    mv1 = _mm_sub_ps(mv1, mv2);
                    mv1 = _mm_mul_ps(mv1, mv1);
                    mres = _mm_add_ps(mres, mv1);
            }
            if (size % 4 > 0) {                
                    for (int i = size - size % 4; i < size; i++)
                            fres += (vec1[i] - vec2[i]) * (vec1[i] - vec2[i]);
            }

            //mres = a,b,c,d
            mv1 = _mm_movelh_ps(mres, mres);   //a,b,a,b
            mv2 = _mm_movehl_ps(mres, mres);   //c,d,c,d
            mres = _mm_add_ps(mv1, mv2);       //res[0],res[1]

            _mm_storeu_ps(ftmp, mres);        

            return fres + ftmp[0] + ftmp[1];
        }

        public void add_vote(int class_)
        {
            m_votes[class_]++;
        }

        public int get_class() 
        {
            return m_class;
        }

        public void set_class(int class_)
        {
            m_class = class_;
        }

        public void lear_votes(int classes_number)
        {
            if (m_votes.Lenght() && classes_number == (int)m_votes.Lenght) {
                    for (int c = 0; c < classes_number; c++)
                            m_votes[c] = 0;
            } else {
                    //m_votes.clear();
                    Array.Clear(m_votes, 0, m_votes.Length);

                    for (int c = 0; c < classes_number; c++)
                            m_votes.push_back(0);
            }
            m_class = 0;
            m_precision = 0.0f;
        }

        //classes 1,2,3  or  2,4,5  or 5,2,1 ... not in ascending order
        public bool evaluate_class(int[] classes, int classes_number)         
        {
            if (classes_number > 0)
            {
                m_precision = 0.0f;

                //get max votes number and assign a class to that node
                int maxvotes = m_votes[0];
                m_class = classes[0];
                for (int c = 1; c < classes_number; c++)
                {
                    if (maxvotes < m_votes[c])
                    {
                        maxvotes = m_votes[c];
                        m_class = classes[c];
                    }
                }

                //calculate node presicion = maxvotes/(cls1votes+cls2votes+ ... )
                if (maxvotes > 0)
                {
                    for (int c = 0; c < classes_number; c++)
                        m_precision += m_votes[c];
                    m_precision = ((float)maxvotes / m_precision);
                }
                else
                {
                    m_class = 0;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
