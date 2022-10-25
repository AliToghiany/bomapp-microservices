import 'package:bomapp/screens/login.dart';
import 'package:flutter/material.dart';
import 'package:onboarding/onboarding.dart';

class WellcomePage extends StatefulWidget {
  const WellcomePage({Key? key}) : super(key: key);

  @override
  State<WellcomePage> createState() => _WellcomePageState();
}

class _WellcomePageState extends State<WellcomePage> {
  late Material materialButton;

  late int index;

  final onboardingPagesList = [];

  @override
  void initState() {
    super.initState();
    materialButton = _skipButton();
    index = 0;
  }

  Material _skipButton({void Function(int)? setIndex}) {
    return Material(
      borderRadius: defaultSkipButtonBorderRadius,
      color: defaultSkipButtonColor,
      child: InkWell(
        borderRadius: defaultSkipButtonBorderRadius,
        onTap: () {
          if (setIndex != null) {
            index = 2;
            setIndex(2);
          }
        },
        child: const Padding(
          padding: defaultSkipButtonPadding,
          child: Text(
            'Skip',
            style: defaultSkipButtonTextStyle,
          ),
        ),
      ),
    );
  }

  Material get _signupButton {
    return Material(
      borderRadius: defaultProceedButtonBorderRadius,
      color: defaultProceedButtonColor,
      child: InkWell(
        borderRadius: defaultProceedButtonBorderRadius,
        onTap: () {
          Navigator.push(context, MaterialPageRoute(builder: (context) {
            return LoginPage();
          }));
        },
        child: const Padding(
          padding: defaultProceedButtonPadding,
          child: Text(
            'Sign up',
            style: defaultProceedButtonTextStyle,
          ),
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
        visualDensity: VisualDensity.adaptivePlatformDensity,
      ),
      home: Scaffold(
          body: Stack(children: [
        Center(
            child: Image.network(
          'https://localhost:44374/reso/animoto_video_346308207_360x640_f15_6nj8.gif',
          width: MediaQuery.of(context).size.width,
          height: MediaQuery.of(context).size.height,
          fit: BoxFit.fill,
        )),
        Onboarding(
          pages: [
            PageModel(
              widget: DecoratedBox(
                decoration: BoxDecoration(
                  color: Colors.transparent,
                  border: Border.all(
                    width: 0.0,
                    color: Colors.transparent,
                  ),
                ),
                child: SingleChildScrollView(
                  controller: ScrollController(),
                  child: Column(
                    children: [
                      Padding(
                        padding: const EdgeInsets.symmetric(
                          horizontal: 45.0,
                          vertical: 90.0,
                        ),
                        child: SizedBox(
                          height: 300,
                        ),
                      ),
                      const Padding(
                        padding: EdgeInsets.symmetric(horizontal: 45.0),
                        child: Align(
                          alignment: Alignment.centerLeft,
                          child: Text(
                            'SECURED BACKUP',
                            style: pageTitleStyle,
                            textAlign: TextAlign.left,
                          ),
                        ),
                      ),
                      const Padding(
                        padding: EdgeInsets.symmetric(
                            horizontal: 45.0, vertical: 10.0),
                        child: Align(
                          alignment: Alignment.centerLeft,
                          child: Text(
                            'Reach your files anytime from any devices anywhere.',
                            style: pageInfoStyle,
                            textAlign: TextAlign.left,
                          ),
                        ),
                      )
                    ],
                  ),
                ),
              ),
            ),
            PageModel(
              widget: DecoratedBox(
                decoration: BoxDecoration(
                  color: Colors.transparent,
                  border: Border.all(
                    width: 0.0,
                    color: Colors.transparent,
                  ),
                ),
                child: SingleChildScrollView(
                  controller: ScrollController(),
                  child: Column(
                    children: [
                      Padding(
                          padding: const EdgeInsets.symmetric(
                            horizontal: 45.0,
                            vertical: 90.0,
                          ),
                          child: SizedBox(
                            height: 300,
                          )),
                      const Padding(
                        padding: EdgeInsets.symmetric(horizontal: 45.0),
                        child: Align(
                          alignment: Alignment.centerLeft,
                          child: Text(
                            'CHANGE AND RISE',
                            style: pageTitleStyle,
                            textAlign: TextAlign.left,
                          ),
                        ),
                      ),
                      const Padding(
                        padding: EdgeInsets.symmetric(
                            horizontal: 45.0, vertical: 10.0),
                        child: Align(
                          alignment: Alignment.centerLeft,
                          child: Text(
                            'Give others access to any file or folders you choose',
                            style: pageInfoStyle,
                            textAlign: TextAlign.left,
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ),
            PageModel(
              widget: DecoratedBox(
                decoration: BoxDecoration(
                  color: Colors.transparent,
                  border: Border.all(
                    width: 0.0,
                    color: Colors.transparent,
                  ),
                ),
                child: SingleChildScrollView(
                  controller: ScrollController(),
                  child: Column(
                    children: [
                      Padding(
                          padding: const EdgeInsets.symmetric(
                            horizontal: 45.0,
                            vertical: 90.0,
                          ),
                          child: SizedBox(
                            height: 300,
                          )),
                      const Padding(
                        padding: EdgeInsets.symmetric(horizontal: 45.0),
                        child: Align(
                          alignment: Alignment.centerLeft,
                          child: Text(
                            'EASY ACCESS',
                            style: pageTitleStyle,
                            textAlign: TextAlign.left,
                          ),
                        ),
                      ),
                      const Padding(
                        padding: EdgeInsets.symmetric(
                            horizontal: 45.0, vertical: 10.0),
                        child: Align(
                          alignment: Alignment.centerLeft,
                          child: Text(
                            'Reach your files anytime from any devices anywhere.',
                            style: pageInfoStyle,
                            textAlign: TextAlign.left,
                          ),
                        ),
                      )
                    ],
                  ),
                ),
              ),
            ),
          ],
          onPageChange: (int pageIndex) {
            index = pageIndex;
          },
          startPageIndex: 0,
          footerBuilder: (context, dragDistance, pagesLength, setIndex) {
            return DecoratedBox(
              decoration: BoxDecoration(
                color: Colors.transparent,
                border: Border.all(
                  width: 0.0,
                  color: Colors.transparent,
                ),
              ),
              child: ColoredBox(
                color: Colors.transparent,
                child: Padding(
                  padding: const EdgeInsets.all(45.0),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      CustomIndicator(
                        netDragPercent: dragDistance,
                        pagesLength: pagesLength,
                        indicator: Indicator(
                          indicatorDesign: IndicatorDesign.line(
                            lineDesign: LineDesign(
                              lineType: DesignType.line_uniform,
                            ),
                          ),
                        ),
                      ),
                      index == pagesLength - 1
                          ? _signupButton
                          : _skipButton(setIndex: setIndex)
                    ],
                  ),
                ),
              ),
            );
          },
        ),
      ])),
    );
  }
}
