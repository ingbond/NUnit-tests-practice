using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void SetUp()
        {
            _videoRepository = new Mock<IVideoRepository>();
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnEmprtyString()
        {
            _videoRepository.Setup(fr => fr.GetUnprocessedVideos())
                .Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_UnprocessVideos_ReturnVideoIds()
        {
            _videoRepository.Setup(fr => fr.GetUnprocessedVideos())
                .Returns(new List<Video> { 
                    new Video { Id=1, IsProcessed = false, Title = "New video" } ,
                    new Video { Id=2, IsProcessed = false, Title = "New video 2" }
                });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2"));
        }
    }
}
