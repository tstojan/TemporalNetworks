%  read labels and x-y data
data = load('MarkovImportantNodesCloseness.txt');     %  read data into the my_xy matrix
%x=['2 \lt 2.25','2 \lt 2.25','2 \lt 2.25','2 \lt 2.25','2 \lt 2.25','2 \lt 2.25','2 \lt 2.25','2 \lt 2.25' ];
%y = randn(10000,1);

[a,b]=hist(data(:),0.04:0.05:0.24); 
bar(b,a,0.60);
%[h,b] = std(data(:));
%figure;
%plot(b,h);
xlabel('Nodes temporal closeness');
ylabel('Frequency %');
grid on;

%plot(Prob,Err1,'r.-',Prob,Err2,'b.-',Prob,Err3,'g.-',Prob,Err4,'c.-',Prob,Err5,'y.-');
%xlabel('P_{err}');           % add axis labels and plot title
%ylabel('Temporal Robustness');

%axis([0.000075 1.000 0.0 1.000],[0.000075 1.000 0.0 1.000]);
%set(gca,'XGrid','on','YGrid','on');
%set(gca,'gridlinestyle','--')
%grid on;
%legend('p = 10^{-4}','p = 10^{-3}','p = 10^{-2}','p = 10^{-1}','p = 1');

%title('Mean monthly precipitation at Portland International Airport');
%plot(Prob,EffSim,'bx-',Prob,EffTheor,'ro-');     %  plot precip vs. month with circles
