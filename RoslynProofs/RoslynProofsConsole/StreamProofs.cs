using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    public class SlideId
    {
        public int Id { get; set; }
    }
    public class StreamProofs
    {
        public void Test1()
        {
            using (Stream stream = File.Open(@"D:\Project\Open XML SDK\Template.pptx", FileMode.Open, FileAccess.Read))
            {
                templateStream = new MemoryStream((int)stream.Length);
                stream.Copy(templateStream);
                templateStream.Position = 0L;

                using (PresentationDocument myPres = PresentationDocument.Open(templateStream, true))
                {

                    var presPart = myPres.PresentationPart;
                    var slideIdList = presPart.Presentation.SlideIdList;

                    var list = slideIdList.ChildElements
                                .Cast<SlideId>()
                                .Select(x => presPart.GetPartById(x.RelationshipId))
                                .Cast<SlidePart>();

                    var tableSlidePart = list.Last();

                    //Use the first slide as a template just for cloning
                    var newtableSlidePart = CloneSlidePart(presPart, tableSlidePart, true);
                    var slideCreated = true;
                    var current = newtableSlidePart;
                    for (var i = 1; i <= 3; i++)
                    {
                        if (!slideCreated)
                        {
                            var newTablePartForNewCoveragePlan = CloneSlidePart(presPart, tableSlidePart, true);
                            current = newTablePartForNewCoveragePlan;
                            slideCreated = true;
                        }

                        SetPlaceholder(current, i);
                        SetNotes(current);


                        GenerateTable(current, presPart, tableSlidePart, i);
                        current.Slide.Save();
                        slideCreated = false;
                    }

                    myPres.PresentationPart.Presentation.Save();

                    //delete the first slide that we used just for cloning
                    //Get slide id to delete
                    var slideIdToDelete = slideIdList.ChildElements[0] as SlideId;

                    // Get the relationship ID of the slide.
                    string slideRelId = slideIdToDelete.RelationshipId;

                    // Remove the slide from the slide list.
                    slideIdList.RemoveChild(slideIdToDelete);

                    // Save the modified presentation.
                    presPart.Presentation.Save();

                    // Get the slide part for the specified slide.
                    var slidePart = presPart.GetPartById(slideRelId) as SlidePart;

                    // Remove the slide part.
                    presPart.DeletePart(slidePart);

                    File.WriteAllBytes(@"D:\Project\Open XML SDK\Output.pptx", templateStream.ToArray());
                }


            }
        }
    }
}
