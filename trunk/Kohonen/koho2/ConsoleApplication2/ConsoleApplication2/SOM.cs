using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class SOM
    {
        int m_status;                   //SOM status after loading

        int m_dimensionality;           //dimension of SOM
        int[] m_dimensions;              //dimensions sizes
        int m_weights_per_node;         //number of weights per node

        List<Node> m_nodes;             //array of nodes

        float[] m_data;                  //data vector to classify
        float[] m_add;                   //normalization params for input data   (x+add)*mul
        float[] m_mul;                   //normalization params for input data


        //Método de construção aqui

        public int status() 
        {
            return m_status;
        }        

        public int get_dimensionality() 
        {
            return m_dimensionality;
        }          

        public int get_weights_per_node() 
        {
            return m_weights_per_node;
        }        

        public int get_nodes_number() 
        {
            return m_nodes.Count;
        }

        public List<Node> get_node()
        {
            return m_nodes;
        }

        public Node get_bmu_node(float[] vec)
        {
            Node pbmu_node = m_nodes.First();
            float mindist = pbmu_node.get_distance(vec);
            float dist;

            for (int i = 1; i < get_nodes_number(); i++) 
            {
                if ((dist = m_nodes[i].get_distance(vec)) < mindist) 
                {
                    mindist = dist;
                    pbmu_node = m_nodes[i];
                }
            }

            return pbmu_node;
        }

        public Node get_bmu_0node(float[] vec)
        {
            Node pbmu_0node = null;
            int n;

            for (n = 0; n < get_nodes_number(); n++) 
            {
                if (m_nodes[n].get_class() == 0) 
                {
                    pbmu_0node = m_nodes[n];
                    break;
                }
            }

            if (pbmu_0node != null) //there is 0class node m_nodes[n]
            { 
                float mindist = pbmu_0node.get_distance(vec), dist;
                for (int i = n + 1; i < get_nodes_number(); i++) 
                {
                    if (m_nodes[i].get_class() == 0 && (dist = m_nodes[i].get_distance(vec)) < mindist) 
                    {
                        mindist = dist;
                        pbmu_0node = m_nodes[i];
                    }
                }

                return pbmu_0node;
            } else
                return null;
        }

        public int save(String fname) 
        {        
            //FILE *fp = _wfopen(fname, L"wt");
            //if (fp != 0) {
            //        fwprintf(fp, L"%d\n", m_dimensionality);
            //        for (int i = 0; i < m_dimensionality; i++)
            //                fwprintf(fp, L"%d ", m_dimensions[i]);
            //        fwprintf(fp, L"\n%d\n%s\n\n", m_weights_per_node, g_distance[m_distance_metric]);

            //        //save classes numbers of nodes
            //        for (int n = 0; n < get_nodes_number(); n++) {
            //                Node *pnode = m_nodes[n];
            //                fwprintf(fp, L" %d", pnode->get_class());

            //                if (!((n + 1) % m_dimensions[0]))
            //                        fwprintf(fp, L"\n");
            //        }
            //        fwprintf(fp, L"\n");

            //        //save norm parameters
            //        fwprintf(fp, L"%s\n", g_normalization[m_normalization]);
            //        for (int i = 0; i < m_weights_per_node; i++)
            //                fwprintf(fp, L"%g\t\t%g\n", m_add[i], m_mul[i]);
            //        fwprintf(fp, L"\n");

            //        //save nodes positions and weights
            //        for (int n = 0; n < get_nodes_number(); n++) {
            //                Node *pnode = m_nodes[n];                        
            //                for (int c = 0; c < m_dimensionality; c++)
            //                        fwprintf(fp, L"%g ", pnode->m_coords[c]);
            //                fwprintf(fp, L"\n");

            //                for (int w = 0; w < m_weights_per_node; w++)
            //                        fwprintf(fp, L"%g\n", pnode->m_weights[w]);
            //                fwprintf(fp, L"\n");
            //        }

            //        fclose(fp);
            //        return 0;
            //} else
                    return -1;
        }

        public int save_2D_distance_map(String fname) 
        {
                //int D = 2;
                //float min_dist = 1.5f;

                //if (get_dimensionality() != D)
                //        return -1;

                //FILE *fp = _wfopen(fname, L"wt");
                //if (fp != 0) {
                //        int n = 0;
                //        for (int i = 0; i < m_dimensions[0]; i++) {
                //                for (int j = 0; j < m_dimensions[1]; j++) {                                
                //                        float dist = 0.0f;
                //                        int nodes_number = 0;
                //                        const Node *pnode = get_node(n++);
                //                        for (int m = 0; m < get_nodes_number(); m++) {
                //                                const Node *node = get_node(m);
                //                                if (node == pnode)
                //                                        continue;
                //                                float tmp = 0.0;
                //                                for (int x = 0; x < D; x++)
                //                                        tmp += pow(*(pnode->get_coords() + x) - *(node->get_coords() + x), 2.0f);
                //                                tmp = sqrt(tmp);
                //                                if (tmp <= min_dist) {
                //                                        nodes_number++;
                //                                        dist += pnode->get_distance(node->m_weights, m_distance_metric);
                //                                }
                //                        }
                //                        dist /= (float)nodes_number;
                //                        fwprintf(fp, L" %f", dist);
                //                }
                //                fwprintf(fp, L"\n");
                //        }
                //        fclose(fp);
                //        return 0;
                //}
                //else 
                        return -2;
        }


        /////////////////////////normalization//////////////////////////////////////////////////////////
        public void compute_normalization(PREC rec)
        {        
            //calculate disp,mean,min,max
            for (int x = 0; x < get_weights_per_node(); x++) 
            {
                m_add[x] = FLT_MAX;     //min
                m_mul[x] = -FLT_MAX;    //max
            }

            for (int y = 0; y < (int)rec->entries.size(); y++) 
            {
                if (rec->entries[y] == 0)
                        continue;
                for (int x = 0; x < get_weights_per_node(); x++) 
                {
                        if (m_add[x] > rec->entries[y]->vec[x]) m_add[x] = rec->entries[y]->vec[x];   //min
                        if (m_mul[x] < rec->entries[y]->vec[x]) m_mul[x] = rec->entries[y]->vec[x];   //max
                }
            }

            for (int x = 0; x < get_weights_per_node(); x++) 
            {
                float mul, add;
                add = -m_add[x];
                if ((m_mul[x] - m_add[x]) != 0.0f)
                        mul = 1.0f / (m_mul[x] - m_add[x]);
                else
                        mul = 1.0f;
                m_add[x] = add;
                m_mul[x] = mul;
            }
           
            //mean values
            int size = 0;
            for (int y = 0; y < (int)rec->entries.size(); y++) 
            {
                    if (rec->entries[y] == 0)
                            continue;
                    for (int x = 0; x < get_weights_per_node(); x++)                                 
                            m_add[x] += rec->entries[y]->vec[x];                        
                    size++;
            }

            for (int x = 0; x < get_weights_per_node(); x++)   //m_add = mean values
                    m_add[x] /= (float)size;

            //dispersions                
            for (int y = 0; y < (int)rec->entries.size(); y++) 
            {
                    if (rec->entries[y] == 0)
                            continue;
                    for (int x = 0; x < rec->entries[y]->size; x++)                                 
                            m_mul[x] += (rec->entries[y]->vec[x] - m_add[x]) * (rec->entries[y]->vec[x] - m_add[x]);                        
            }

            //m_add; m_mul
            for (int x = 0; x < get_weights_per_node(); x++) { //m_add = -mean values;  m_mul = 1/disp
                    float disp = sqrt(m_mul[x] / float(size - 1));
                    if (disp != 0.0f)
                            m_mul[x] = 1.0f / disp;
                    else
                            m_mul[x] = 1.0f;
                    m_add[x] = -m_add[x];
            }
        
                
        }

        public float[] normalize(float[] vec)
        {
                switch (m_normalization) {
                default:
                case NONE:
                        for (int x = 0; x < get_weights_per_node(); x++)
                                m_data[x] = vec[x];
                        break;

                case MNMX:
                        for (int x = 0; x < get_weights_per_node(); x++)
                                m_data[x] = (0.9f - 0.1f) * (vec[x] + m_add[x]) * m_mul[x] + 0.1f;                
                        break;

                case ZSCR:
                        for (int x = 0; x < get_weights_per_node(); x++)
                                m_data[x] = (vec[x] + m_add[x]) * m_mul[x];                
                        break;

                case SIGM:
                        for (int x = 0; x < get_weights_per_node(); x++)
                                m_data[x] = 1.0f / (1.0f + exp(-((vec[x] + m_add[x]) * m_mul[x])));                
                        break;

                case ENRG:                
                        float energy = 0.0f;
                        for (int x = 0; x < get_weights_per_node(); x++)
                                energy += vec[x] * vec[x];
                        energy = sqrt(energy);

                        for (int x = 0; x < get_weights_per_node(); x++)
                                m_data[x] = vec[x] / energy;                
                        break;
                }
                return m_data;
        }


        /////////////////////calculate initial R0 for 1st epoch/////////////////////////////////////////
        public float R0() 
        {
            float R = 0.0f;

            for (int i = 0; i < m_dimensionality; i++)
                    if ((float)m_dimensions[i] > R)
                            R = (float)m_dimensions[i];

            return R / 2.0f;
        }


        //////////////////////////////////training///////////////////////////////////////////////////////////////
        public void train(float[] vectors, float R, float learning_rule)   
        {
            for (int n = 0; n < (int)vectors.Length; n++) 
            {
                        
                float *pdata = normalize(vectors->at(n));

                //get best node
                Node *bmu_node = get_bmu_node(pdata);
                const float *p1 = bmu_node->get_coords();                

                if (R <= 1.0f)  //adjust BMU node only
                        bmu_node->train(pdata, learning_rule);
                else {
                    for (int i = 0; i < get_nodes_number(); i++) //adjust weights within R
                    { 
                            const float *p2 = m_nodes[i]->get_coords();
                            float dist = 0.0f;

                            for (int p = 0; p < m_dimensionality; p++)     //dist = sqrt((x1-y1)^2 + (x2-y2)^2 + ...)  distance to node
                                    dist += (p1[p] - p2[p]) * (p1[p] - p2[p]);
                            dist = sqrt(dist);

                            if (m_train_mode == FAST && dist > R) 
                                    continue;

                            float y = exp(-(1.0f * dist * dist) / (R * R));
                            m_nodes[i]->train(pdata, learning_rule * y);
                    }

                }
            }
        }


        //////VOTING scheme best node to a vector
        void vote_nodes_from(PREC rec)
        {
                //rec->clsnum = [cls 1][cls 2] ... [cls N]   N entries   examle: 0,1,2  3,1,2   1,4,10 missed classes

                //clear votes for classes of all nodes
                for (int n = 0; n < get_nodes_number(); n++)
                        m_nodes[n]->clear_votes((int)rec->clsnum.size());

                while (true) { //untill unclassified nodes m_class=0
                        //add vote to a best node for a given class
                        for (int y = 0; y < (int)rec->entries.size(); y++) {
                                if (rec->entries[y] == 0)
                                        continue;

                                const float *pdata = normalize(rec->entries[y]->vec);
                                Node *pbmu_0node = get_bmu_0node(pdata);
                        
                                //no more m_class=0 nodes
                                if (pbmu_0node == 0) 
                                        return;  

                                //check class location in REC->clsnum[] array
                                int c = rec->entries[y]->cls;
                                for (int i = 0; i < (int)rec->clsnum.size(); i++) {
                                        if (rec->clsnum[i] == c) {
                                                c = i;
                                                break;
                                        }
                                }

                                pbmu_0node->add_vote(c);
                        }

                        //assign class from the max number of votes for a class
                        for (int n = 0; n < get_nodes_number(); n++) {
                                if (m_nodes[n]->get_class() == 0)
                                        m_nodes[n]->evaluate_class(&rec->clsnum[0], (int)rec->clsnum.size());
                        }
                }
        }

        //////DIRECT scheme best vector to a node
        public void assign_nodes_to(PREC rec)
        {
            //run thru nodes and get best vector matching
            for (int n = 0; n < get_nodes_number(); n++) 
            {
                m_nodes[n].clear_votes();
                
                int index = 0;
                float mindist = FLT_MAX, dist;

                for (int i = 0; i < (int)rec->entries.size(); i++) 
                {
                    if (rec->entries[i] == 0)
                            continue;

                    float[] pdata = normalize(rec->entries[i]->vec);
                    if ((dist = m_nodes[n].get_distance(pdata)) < mindist) 
                    {
                        mindist = dist;
                        index = i;
                    }
                }

                m_nodes[n].set_class(rec->entries[index]->cls);
            }
        }


        ////////////////////////////////////testing///////////////////////////////////////////////////////
        public Node classify(float[] vec)
        {
            Node pbmu_node = m_nodes.First();
            float[] pdata = normalize(vec);
            float mindist = pbmu_node.get_distance(pdata), dist;

            for (int n = 1; n < get_nodes_number(); n++) 
            {
                if ((dist = m_nodes[n].get_distance(pdata)) < mindist) 
                {
                    mindist = dist;
                    pbmu_node = m_nodes[n];
                }
            }
            return pbmu_node;
        }

    }
}
