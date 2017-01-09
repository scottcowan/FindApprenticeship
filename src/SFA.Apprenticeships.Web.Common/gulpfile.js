/// <binding AfterBuild='default' Clean='clean, cleantarget' />
'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');
var gutil = require('gulp-util');
var copy = require('gulp-copy');
var clean = require('gulp-clean');
var merge = require('merge-stream');

var repo_root = __dirname + '/';
var govuk_frontend_toolkit_root = repo_root + 'node_modules/govuk_frontend_toolkit/stylesheets'; // 1.
var govuk_frontend_toolkit_design_patterns = repo_root + 'node_modules/govuk_frontend_toolkit/stylesheets/design-patterns'; // 1.
var govuk_elements_sass_root = repo_root + 'node_modules/govuk-elements-sass/public/sass';       // 2.

var buildDir = './build/';  

var outputPaths = [
    { key: 'recruit', path: repo_root + '../SFA.Apprenticeships.Web.Recruit/Content/_assets/' },
    { key: 'manage', path: repo_root + '../SFA.Apprenticeships.Web.Manage/Content/_assets/' },
    { key: 'find', path: repo_root + '../SFA.Apprenticeships.Web.Candidate/Content/_assets/' }
];

var projectJsPaths = [
    { key: 'recruit', path: repo_root + 'Content/projectJs/Recruit/**/*' },
    { key: 'manage', path: repo_root + 'Content/projectJs/Manage/**/*' },
    { key: 'find', path: repo_root + 'Content/projectJs/Find/**/*' }
];

gulp.task('default', ['clean', 'cleantarget', 'styles', 'merge-base', 'merge-font-awesome', 'copy']);

gulp.task('clean',
    function() {
        return gulp.src(buildDir, { read: false })
            .pipe(clean({ force: true }));
    });

// Compile scss files to css
gulp.task('styles', ['clean', 'cleantarget'], function () {
    return gulp.src('./Content/scss/**/*.scss')
      .pipe(sass({
          includePaths: [
            govuk_frontend_toolkit_root,
            govuk_elements_sass_root,
            govuk_frontend_toolkit_design_patterns
          ]
      }).on('error', sass.logError))
      .pipe(gulp.dest(buildDir + 'css'));
});

gulp.task('merge-base', ['clean', 'cleantarget'], function () {
    return merge(gulp.src(repo_root + 'node_modules/govuk_template_ejs/assets/images/**/*')
            .pipe(gulp.dest(buildDir + 'img')),
        gulp.src(repo_root + 'node_modules/govuk_frontend_toolkit/images/**/*')
            .pipe(gulp.dest(buildDir + 'img')),
        gulp.src(repo_root + 'node_modules/govuk_template_ejs/assets/stylesheets/**/*')
            .pipe(gulp.dest(buildDir + 'css')),
        gulp.src(repo_root + 'Content/img/**/*')
            .pipe(gulp.dest(buildDir + 'img')),
        gulp.src(repo_root + 'Content/libs/**/*')
            .pipe(gulp.dest(buildDir + 'js')),
        gulp.src(repo_root + 'Content/libs/vendor/ckeditor/**/*')
            .pipe(gulp.dest(buildDir + 'js/ckeditor')),
        gulp.src(repo_root + 'node_modules/govuk_template_ejs/assets/javascripts/**/*')
            .pipe(gulp.dest(buildDir + 'js')));
});

gulp.task('merge-font-awesome', ['clean', 'cleantarget'],
    function() {
        return merge(
            gulp.src([repo_root + 'node_modules/font-awesome/css/**/*', '!' + repo_root + 'node_modules/font-awesome/css/**/*.min.*'])
                .pipe(gulp.dest(buildDir + 'css')),
            gulp.src(repo_root + 'node_modules/font-awesome/fonts/**/*')
                .pipe(gulp.dest(buildDir + 'fonts')));
});

gulp.task('cleantarget', function () {
    var merged = merge();

    for (var i = 0; i < outputPaths.length; i++) {
        merged.add(gulp.src(outputPaths[i].path, { read: false })
            .pipe(clean({force:true})));
    }

    return merged;
});

gulp.task('copy', ['clean', 'cleantarget', 'styles', 'merge-base', 'merge-font-awesome'], function() {   
    var pipe = gulp.src(buildDir + '**/*');
    var merged = merge(pipe);

    for (var i = 0; i < outputPaths.length; i++) {
        merged.add(pipe.pipe(gulp.dest(outputPaths[i].path)));
    }

    for (var i = 0; i < outputPaths.length; i++) {
        for (var p = 0; p < projectJsPaths.length; p++) {
            if (outputPaths[i].key === projectJsPaths[p].key) {
                merged.add(gulp.src(projectJsPaths[p].path).pipe(gulp.dest(outputPaths[i].path + '/js/nas')));
                break;
            }
        }
    }

    return merged;
});