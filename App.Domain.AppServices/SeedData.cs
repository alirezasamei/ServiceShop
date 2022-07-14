using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Domain.Core.Operator.Contracts.Repositories;
using App.Domain.Core.Operator.Dtos;
using App.Domain.Core.Service.Contracts.Repositories;
using App.Domain.Core.Service.Dtos;
using App.Domain.Core.User.Contracts.Repositories;
using App.Domain.Core.User.Dtos;

namespace App.Domain.AppServices
{
    public class SeedData
    {
        private readonly IFileTypeCommandRepository _fileTypeCommandRepository;
        private readonly IFileTypeQueryRepository _fileTypeQueryRepository;
        private readonly ICommentCommandRepository _commentCommandRepository;
        private readonly ICommentQueryRepository _commentQueryRepository;
        private readonly IEvaluationCommandRepository _evaluationCommandRepository;
        private readonly IEvaluationQueryRepository _evaluationQueryRepository;
        private readonly IEvaluationTitleCommandRepository _evaluationTitleCommandRepository;
        private readonly IEvaluationTitleQueryRepository _evaluationTitleQueryRepository;
        private readonly IExpertCommandRepository _expertCommandRepository;
        private readonly IExpertQueryRepository _expertQueryRepository;
        private readonly IExpertServiceCommandRepository _expertServiceCommandRepository;
        private readonly IExpertServiceFileCommandRepository _expertServiceFileCommandRepository;
        private readonly IExpertServiceFileQueryRepository _expertServiceFileQueryRepository;
        private readonly IExpertServiceQueryRepository _expertServiceQueryRepository;
        private readonly IPastWorkCommandRepository _pastWorkCommandRepository;
        private readonly IPastWorkQueryRepository _pastWorkQueryRepository;
        private readonly ITenderCommandRepository _tenderCommandRepository;
        private readonly ITenderQueryRepository _tenderQueryRepository;
        private readonly IOperatorCommandRepository _operatorCommandRepository;
        private readonly IOperatorQueryRepository _operatorQueryRepository;
        private readonly IServiceCommandRepository _serviceCommandRepository;
        private readonly IServiceFileCommandRepository _serviceFileCommandRepository;
        private readonly IServiceFileQueryRepository _serviceFileQueryRepository;
        private readonly IServiceQueryRepository _serviceQueryRepository;
        private readonly IOrderCommandRepository _orderCommandRepository;
        private readonly IOrderQueryRepository _orderQueryRepository;
        private readonly IOrderStateCommandRepository _orderStateCommandRepository;
        private readonly IOrderStateQueryRepository _orderStateQueryRepository;
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public SeedData(
            IFileTypeCommandRepository fileTypeCommandRepository,
            IFileTypeQueryRepository fileTypeQueryRepository,
            ICommentCommandRepository commentCommandRepository,
            ICommentQueryRepository commentQueryRepository,
            IEvaluationCommandRepository evaluationCommandRepository,
            IEvaluationQueryRepository evaluationQueryRepository,
            IEvaluationTitleCommandRepository evaluationTitleCommandRepository,
            IEvaluationTitleQueryRepository evaluationTitleQueryRepository,
            IExpertCommandRepository expertCommandRepository,
            IExpertQueryRepository expertQueryRepository,
            IExpertServiceCommandRepository expertServiceCommandRepository,
            IExpertServiceFileCommandRepository expertServiceFileCommandRepository,
            IExpertServiceFileQueryRepository expertServiceFileQueryRepository,
            IExpertServiceQueryRepository expertServiceQueryRepository,
            IPastWorkCommandRepository pastWorkCommandRepository,
            IPastWorkQueryRepository pastWorkQueryRepository,
            ITenderCommandRepository tenderCommandRepository,
            ITenderQueryRepository tenderQueryRepository,
            IOperatorCommandRepository operatorCommandRepository,
            IOperatorQueryRepository operatorQueryRepository,
            IServiceCommandRepository serviceCommandRepository,
            IServiceFileCommandRepository serviceFileCommandRepository,
            IServiceFileQueryRepository serviceFileQueryRepository,
            IServiceQueryRepository serviceQueryRepository,
            IOrderCommandRepository orderCommandRepository,
            IOrderQueryRepository orderQueryRepository,
            IOrderStateCommandRepository orderStateCommandRepository,
            IOrderStateQueryRepository orderStateQueryRepository,
            IUserCommandRepository userCommandRepository,
            IUserQueryRepository userQueryRepository
            )
        {
            _fileTypeCommandRepository = fileTypeCommandRepository;
            _fileTypeQueryRepository = fileTypeQueryRepository;
            _commentCommandRepository = commentCommandRepository;
            _commentQueryRepository = commentQueryRepository;
            _evaluationCommandRepository = evaluationCommandRepository;
            _evaluationQueryRepository = evaluationQueryRepository;
            _evaluationTitleCommandRepository = evaluationTitleCommandRepository;
            _evaluationTitleQueryRepository = evaluationTitleQueryRepository;
            _expertCommandRepository = expertCommandRepository;
            _expertQueryRepository = expertQueryRepository;
            _expertServiceCommandRepository = expertServiceCommandRepository;
            _expertServiceFileCommandRepository = expertServiceFileCommandRepository;
            _expertServiceFileQueryRepository = expertServiceFileQueryRepository;
            _expertServiceQueryRepository = expertServiceQueryRepository;
            _pastWorkCommandRepository = pastWorkCommandRepository;
            _pastWorkQueryRepository = pastWorkQueryRepository;
            _tenderCommandRepository = tenderCommandRepository;
            _tenderQueryRepository = tenderQueryRepository;
            _operatorCommandRepository = operatorCommandRepository;
            _operatorQueryRepository = operatorQueryRepository;
            _serviceCommandRepository = serviceCommandRepository;
            _serviceFileCommandRepository = serviceFileCommandRepository;
            _serviceFileQueryRepository = serviceFileQueryRepository;
            _serviceQueryRepository = serviceQueryRepository;
            _orderCommandRepository = orderCommandRepository;
            _orderQueryRepository = orderQueryRepository;
            _orderStateCommandRepository = orderStateCommandRepository;
            _orderStateQueryRepository = orderStateQueryRepository;
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
        }
        public async Task Seed()
        {
            var operatorId = await _operatorCommandRepository.Add(new OperatorDto { Email = "operator@email.com", IsActive = true, IsDeleted = false, Mobile = "09123456789", Name = "اپراتور", SubmitDate = DateTime.Now });
            var expertId = await _expertCommandRepository.Add(new ExpertDto { Address = "آدرس متخصص", Email = "expert@email.com", ImageName = "ExpertImage.jpg", IsActive = true, IsDeleted = false, Mobile = "09123456789", Name = "متضصص", SubmitDate = DateTime.Now });
            var userId = await _userCommandRepository.Add(new UserDto { Address = "آدرس کاربر", Email = "user@email.com", IsActive = true, IsDeleted = false, Mobile = "09123456789", Name = "کاربر", SubmitDate = DateTime.Now });
            var fileTypeId = await _fileTypeCommandRepository.Add("Image");
            var evaluationTitleId = await _evaluationTitleCommandRepository.Add("کیفیت");
            var serviceId = await _serviceCommandRepository.Add(new ServiceDto { CreationDate = DateTime.Now, Description = "توضیحات: سرویس یا تخصص", ImageName = "ServiceImage.jpg", IsActive = true, IsDeleted = false, Name = "سرویس کولر", Price = 1500000 });
            var expertServiceId = await _expertServiceCommandRepository.Add(new ExpertServiceDto { CreationDate = DateTime.Now, ExpertId = expertId, IsActive = true, IsDeleted = false, ServiceId = serviceId });
            var pastWorkId = await _pastWorkCommandRepository.Add(new PastWorkDto { ComplitionDate = DateTime.Now, ExpertServiceId = expertServiceId, IsDeleted = false, Price = 1500000, UserId = 1 });
            var evaluationId = await _evaluationCommandRepository.Add(new EvaluationDto { EvaluationTitleId = evaluationTitleId, ExpertServiceId = expertServiceId, PastWorkId = pastWorkId, Score = 5 });
            var expertServiceFileId = await _expertServiceFileCommandRepository.Add(new ExpertServiceFileDto { CreationDate = DateTime.Now, Description = "توضیحات: هر تخصص یا سرویس مربوط به یک متخصص", ExpertServiceId = expertServiceId, FileTypeId = fileTypeId, IsDeleted = false, NameWithExtention = "ExpertServiceImage.jpg" });
            var commentId = await _commentCommandRepository.Add(new CommentDto { DislikeCount = 1, ExpertServiceId = expertServiceId, IsConfirmed = true, LikeCount = 5, Text = "متن کامنت", Title = "عنوان کامنت", UserId = userId });
            var orderStateId = await _orderStateCommandRepository.Add("منتظر پیشنهاد متخصصان");
            var orderId = await _orderCommandRepository.Add(new OrderDto { IsDeleted = false, OrderStateId = orderStateId, RegisterDate = DateTime.Now, ServiceId = serviceId, UserId = userId });
            var tenderId = await _tenderCommandRepository.Add(new TenderDto { ExpertId = expertId, OrderId = orderId, Price = 1500000, RegisterDate = DateTime.Now, RequiredTime = TimeSpan.FromHours(2.5), StartDate = DateTime.Now + TimeSpan.FromDays(2) });
            var serviceFileId = await _serviceFileCommandRepository.Add(new ServiceFileDto { CreationDate = DateTime.Now, Description = "توضیحات: فایل مربوط به هر سرویس", FileTypeId = fileTypeId, IsDeleted = false, NameWithExtention = "ServiceImage.jpg", ServiceId = serviceId });
        }
    }
}