using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;



namespace trash_xml_json  // это мой максимум, я так и не поняла просто куда нада было пихать наши темы
                          // зато теперь немного понимаю, с чем едят xml и json
{
    public partial class Form1 : Form
    {
        private List<Entity> entities = new List<Entity> ();
        public Form1()
        {
            InitializeComponent();
        }
        private void PopulateTreeView()
        {
            treeViewEntities.Nodes.Clear();

            foreach (Entity entity in entities)
            {
                TreeNode node = new TreeNode(entity.Name);
                node.Tag = entity;
                treeViewEntities.Nodes.Add(node);
            }
        }
        private void DisplayEntityProperties(Entity entity)
        {
            dataGridViewProperties.Rows.Clear();

            foreach (KeyValuePair<string, string> property in entity.Properties)
            {
                dataGridViewProperties.Rows.Add(property.Key, property.Value);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag is Entity)
            {
                Entity selectedEntity = (Entity)e.Node.Tag;
                DisplayEntityProperties(selectedEntity);
            }
        }
        public void SaveToXml(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Entity>));
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(stream, entities);
            }
        }
        public void SaveToJson(string fileName)
        {
            string json = JsonConvert.SerializeObject(entities);
            File.WriteAllText(fileName, json);
        }

        private void SaveToXml(object sender, EventArgs e)
        {
            SaveToXml("entities.xml");
        }

        private void SaveToJson(object sender, EventArgs e)
        {
            SaveToJson("entities.json");
        }
    }
}
