using BeatBox.BLL.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBox.BLL.Service
{
    public class EntityService
    {
        public EntityService()
        {
            _categoryService = new CategoryRepository();
            _melodistService = new MelodistRepository();
            _singerService = new SingerRepository();
            _songDetailService = new SongDetailRepository();
            _songService = new SongRepository();
            _songWriterService = new SongWriterRepository();
            _webUserService = new WebUserRepository();
        }

        private WebUserRepository _webUserService;

        public WebUserRepository WebUserService
        {
            get { return _webUserService; }
            set { _webUserService = value; }
        }

        private CategoryRepository _categoryService;

        public CategoryRepository categoryService
        {
            get { return _categoryService; }
            set { _categoryService = value; }
        }

        private MelodistRepository _melodistService;

        public MelodistRepository MelodistService
        {
            get { return _melodistService; }
            set { _melodistService = value; }
        }

        private SingerRepository _singerService;

        public SingerRepository SingerService
        {
            get { return _singerService; }
            set { _singerService = value; }
        }
        private SongDetailRepository _songDetailService;

        public SongDetailRepository SongDetailService
        {
            get { return _songDetailService; }
            set { _songDetailService = value; }
        }

        private SongRepository _songService;

        public SongRepository SongService
        {
            get { return _songService; }
            set { _songService = value; }
        }

        private SongWriterRepository _songWriterService;

        public SongWriterRepository SongWriterService
        {
            get { return _songWriterService; }
            set { _songWriterService = value; }
        }

    }
}
